namespace AmbiSocial.Domain.Common.Events.Posts;

public class PostDeletedEvent : IDomainEvent
{
    public PostDeletedEvent(int id)
        => this.Id = id;

    public int Id { get; }
}