namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostPublishedEvent : IDomainEvent
{
    public PostPublishedEvent(int id, string imageUrl, string description)
    {
        Id = id;
        ImageUrl = imageUrl;
        Description = description;
    }

    public int Id { get; }

    public string ImageUrl { get; }

    public string Description { get; }
}