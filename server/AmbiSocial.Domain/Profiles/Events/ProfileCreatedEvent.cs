namespace AmbiSocial.Domain.Profiles.Events;

using Common;

public class ProfileCreatedEvent : IDomainEvent
{
    public ProfileCreatedEvent(
        string userName,
        string? avatarUrl,
        string? biography)
    {
        this.UserName = userName;
        this.AvatarUrl = avatarUrl;
        this.Biography = biography;
    }

    public string UserName { get; }

    public string? AvatarUrl { get; }

    public string? Biography { get; }
}