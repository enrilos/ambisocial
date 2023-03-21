namespace AmbiSocial.Domain.Common.Events.Posts;

public class PostDescriptionUpdatedEvent : IDomainEvent
{
    public PostDescriptionUpdatedEvent(int id, string description)
    {
        this.Id = id;
        this.Description = description;
    }

    public int Id { get; }

    public string Description { get; }
}