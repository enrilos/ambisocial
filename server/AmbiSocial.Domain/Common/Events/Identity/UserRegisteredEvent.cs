namespace AmbiSocial.Domain.Common.Events.Identity;

public class UserRegisteredEvent : IDomainEvent
{
    public UserRegisteredEvent(string userName)
        => this.UserName = userName;

    public string UserName { get; }
}