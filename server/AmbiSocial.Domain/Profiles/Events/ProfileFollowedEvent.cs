namespace AmbiSocial.Domain.Profiles.Events;

using Common;

public class ProfileFollowedEvent : IDomainEvent
{
    public ProfileFollowedEvent(
        string followerUserName,
        string followedUserName)
    {
        this.FollowerUserName = followerUserName;
        this.FollowedUserName = followedUserName;
    }

    public string FollowerUserName { get; }

    public string FollowedUserName { get; }
}