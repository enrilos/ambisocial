namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostCreatedEvent : IDomainEvent
{
    public PostCreatedEvent(string imageUrl, string description)
    {
        this.ImageUrl = imageUrl;
        this.Description = description;
    }

    public string ImageUrl { get; }

    public string Description { get; }
}