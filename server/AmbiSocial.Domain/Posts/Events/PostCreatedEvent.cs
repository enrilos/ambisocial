namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostCreatedEvent : IDomainEvent
{
    public PostCreatedEvent(string imageUrl, string description, string userName)
    {
        this.ImageUrl = imageUrl;
        this.Description = description;
        this.UserName = userName;
    }

    public string ImageUrl { get; }

    public string Description { get; }

    public string UserName { get; }
}