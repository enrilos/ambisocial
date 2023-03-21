namespace AmbiSocial.Domain.Identity.Events;

using Common;

public class UserRegisteredEvent : IDomainEvent
{
    public UserRegisteredEvent(string userName)
        => UserName = userName;

    public string UserName { get; }
}