namespace AmbiSocial.Domain.Posts.Events;

using Common;

public class PostDeletedEvent : IDomainEvent
{
    public PostDeletedEvent(int id)
        => Id = id;

    public int Id { get; }
}