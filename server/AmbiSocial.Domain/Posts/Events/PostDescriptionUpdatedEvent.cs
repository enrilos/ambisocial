namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostDescriptionUpdatedEvent : IDomainEvent
{
    public PostDescriptionUpdatedEvent(int id, string description)
    {
        Id = id;
        Description = description;
    }

    public int Id { get; }

    public string Description { get; }
}