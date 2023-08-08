namespace AmbiSocial.Domain.Profiles.Models;

using Common;
using Common.Models;
using Events;
using Exceptions;
using Posts.Exceptions;
using Posts.Models;

using static Common.Models.ModelConstants.Common;

public class Profile : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Post> posts;
    private readonly HashSet<Follower> followers;
    private readonly HashSet<Follower> followed;

    internal Profile(
        string userName,
        string avatarUrl,
        string description)
    {
        this.Validate(userName, avatarUrl, description);

        this.UserName = userName;
        this.AvatarUrl = avatarUrl;
        this.Description = description;

        this.posts = new();
        this.followers = new();
        this.followed = new();
    }

    public string UserName { get; private set; }

    public string AvatarUrl { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<Post> Posts => this.posts.ToList().AsReadOnly();

    public IReadOnlyCollection<Follower> Followers => this.followers.ToList().AsReadOnly();

    public IReadOnlyCollection<Follower> Followed => this.followed.ToList().AsReadOnly();

    public Profile UpdateAvatarUrl(string avatarUrl)
    {
        this.ValidateAvatarUrl(avatarUrl);

        this.AvatarUrl = avatarUrl;

        return this;
    }

    public Profile UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    public Profile AddPost(Post post)
    {
        Guard.AgainstNull<InvalidPostException>(post);

        this.posts.Add(post);

        return this;
    }

    public Profile UpdatePostDescription(int postId, string description)
    {
        var profilePost = this.posts.SingleOrDefault(x => x.Id == postId);

        if (profilePost is null)
        {
            throw new InvalidPostException("No such post exists for this profile");
        }

        profilePost.UpdateDescription(description);

        return this;
    }

    public Profile AddFollower(Profile profile)
    {
        this.ValidateFollower(profile);

        Guard.AgainstNull<InvalidFollowerException>(profile, nameof(Follower));

        this.followers.Add(new Follower(profile, this));

        this.RaiseEvent(new ProfileFollowedEvent(profile.UserName, this.UserName));

        return this;
    }

    public Profile AddFollowed(Profile profile)
    {
        this.ValidateFollower(profile);

        Guard.AgainstNull<InvalidFollowerException>(profile, nameof(Follower));

        this.followed.Add(new Follower(this, profile));

        this.RaiseEvent(new ProfileFollowedEvent(this.UserName, profile.UserName));

        return this;
    }

    private void Validate(string userName, string avatarUrl, string description)
    {
        this.ValidateUserName(userName);
        this.ValidateAvatarUrl(avatarUrl);

        if (description is not null)
        {
            this.ValidateDescription(description);
        }
    }

    private void ValidateUserName(string userName)
        => Guard.ForStringLength<InvalidProfileException>(
            userName,
            MinNameLength,
            MaxNameLength,
            nameof(this.UserName));

    private void ValidateAvatarUrl(string url)
        => Guard.ForValidUrl<InvalidProfileException>(
            url,
            nameof(this.AvatarUrl));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidProfileException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));

    private void ValidateFollower(Profile follower)
    {
        if (this == follower
            || this.Id == follower.Id
            || this.UserName == follower.UserName)
        {
            throw new InvalidFollowerException();
        }
    }
}