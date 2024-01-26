namespace AmbiSocial.Domain.Profiles.Events;

using Common;

public class ProfileDeletedEvent : IDomainEvent
{
    public ProfileDeletedEvent(string username)
    {
        this.UserName = username;
    }

    public string UserName { get; }
}
