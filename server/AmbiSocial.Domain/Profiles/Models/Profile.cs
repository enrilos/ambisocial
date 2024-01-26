namespace AmbiSocial.Domain.Profiles.Models;

using System;
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
        string? avatarUrl,
        string? biography)
    {
        this.Validate(userName, avatarUrl, biography);

        this.UserName = userName;
        this.AvatarUrl = avatarUrl;
        this.Biography = biography;

        this.posts = new();
        this.followers = new();
        this.followed = new();

        this.RaiseEvent(new ProfileCreatedEvent(
            this.UserName,
            this.AvatarUrl,
            this.Biography
        ));
    }

    public string UserName { get; private set; }

    public string? AvatarUrl { get; private set; }

    public string? Biography { get; private set; }

    public IReadOnlyCollection<Post> Posts => this.posts.ToList().AsReadOnly();

    public IReadOnlyCollection<Follower> Followers => this.followers.ToList().AsReadOnly();

    public IReadOnlyCollection<Follower> Followed => this.followed.ToList().AsReadOnly();

    public void Update(
        string? avatarUrl,
        string? biography)
    {
        this.UpdateAvatarUrl(avatarUrl)
            .UpdateBiography(biography);

        this.RaiseEvent(new ProfileUpdatedEvent(
            this.UserName,
            this.AvatarUrl,
            this.Biography
        ));
    }

    public Profile UpdateAvatarUrl(string? avatarUrl)
    {
        if (avatarUrl is not null)
        {
            Ensure.Url<InvalidProfileException>(avatarUrl);
        }

        this.AvatarUrl = avatarUrl;

        return this;
    }

    public Profile UpdateBiography(string? biography)
    {
        if (biography is not null)
        {
            this.ValidateBiography(biography);
        }

        this.Biography = biography;

        return this;
    }

    public Profile AddPost(Post post)
    {
        Ensure.NotNull<InvalidPostException>(post);

        this.posts.Add(post);

        return this;
    }

    /// <summary>
    /// This Profile's Followers collection will be updated with the provided argument profile.
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    public Profile AddFollower(Profile profile)
    {
        this.ValidateFollower(profile);

        Ensure.NotNull<InvalidFollowerException>(profile);

        this.followers.Add(new Follower(profile, this));

        this.RaiseEvent(new ProfileFollowedEvent(profile.UserName, this.UserName));

        return this;
    }

    /// <summary>
    /// This Profile will start following the provided argument profile.
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    public Profile AddFollowed(Profile profile)
    {
        this.ValidateFollower(profile);

        Ensure.NotNull<InvalidFollowerException>(profile);

        this.followed.Add(new Follower(this, profile));

        this.RaiseEvent(new ProfileFollowedEvent(this.UserName, profile.UserName));

        return this;
    }

    public override void Delete(DateTime now)
    {
        base.Delete(now);

        this.RaiseEvent(new ProfileDeletedEvent(this.UserName));
    }

    private void Validate(string userName, string? avatarUrl, string? biography)
    {
        this.ValidateUserName(userName);

        if (avatarUrl is not null)
        {
            Ensure.Url<InvalidProfileException>(avatarUrl);
        }

        if (biography is not null)
        {
            this.ValidateBiography(biography);
        }
    }

    private void ValidateUserName(string userName)
        => Ensure.Range<InvalidProfileException>(
            userName,
            MinNameLength,
            MaxNameLength);

    private void ValidateBiography(string biography)
        => Ensure.Range<InvalidProfileException>(
            biography,
            MinDescriptionLength,
            MaxDescriptionLength);

    private void ValidateFollower(Profile follower)
    {
        if (this == follower)
        {
            throw new InvalidFollowerException();
        }
    }
}