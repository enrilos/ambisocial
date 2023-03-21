namespace AmbiSocial.Domain.Common.Events.Posts;

public class PostPublishedEvent : IDomainEvent
{
    public PostPublishedEvent(int id, string imageUrl, string description)
    {
        this.Id = id;
        this.ImageUrl = imageUrl;
        this.Description = description;
    }

    public int Id { get; }

    public string ImageUrl { get; }

    public string Description { get; }
}