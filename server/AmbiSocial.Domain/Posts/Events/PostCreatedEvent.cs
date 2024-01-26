namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostCreatedEvent : IDomainEvent
{
    public PostCreatedEvent(
        int id,
        string imageUrl,
        string description,
        string profileUserName)
    {
        this.Id = id;
        this.ImageUrl = imageUrl;
        this.Description = description;
        this.ProfileUserName = profileUserName;
    }

    public int Id { get; }

    public string ImageUrl { get; }

    public string Description { get; }

    public string ProfileUserName { get; }
}