namespace AmbiSocial.Domain.Profiles.Events;

using Common;

public class ProfileUpdatedEvent : IDomainEvent
{
    public ProfileUpdatedEvent(
        string username,
        string? avatarUrl,
        string? biography)
    {
        this.UserName = username;
        this.AvatarUrl = avatarUrl;
        this.Biography = biography;
    }

    public string UserName { get; }

    public string? AvatarUrl { get; }

    public string? Biography { get; }
}