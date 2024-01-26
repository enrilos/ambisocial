namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostUpdatedEvent : IDomainEvent
{
    public PostUpdatedEvent(
        int id,
        string description)
    {
        this.Id = id;
        this.Description = description;
    }

    public int Id { get; }

    public string Description { get; }
}