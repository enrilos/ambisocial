namespace AmbiSocial.Domain.Profiles.Models;

using Common;
using Common.Models;
using Exceptions;
using Posts.Models.Posts;

using static Common.Models.ModelConstants.Common;

public class Profile : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Post> posts;
    private readonly HashSet<Profile> followers;
    private readonly HashSet<Profile> following;

    internal Profile(string userName, string description)
    {
        this.Validate(userName, description);

        this.UserName = userName;
        this.Description = description;

        this.posts = new();
        this.followers = new();
        this.following = new();
    }

    public string UserName { get; private set; }

    public string Description { get; private set; }

    public IReadOnlyCollection<Post> Posts => this.posts.ToList().AsReadOnly();

    public IReadOnlyCollection<Profile> Followers => this.followers.ToList().AsReadOnly();

    public IReadOnlyCollection<Profile> Following => this.following.ToList().AsReadOnly();

    private void Validate(string userName, string description)
    {
        this.ValidateUserName(userName);

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

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidProfileException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));
}