namespace AmbiSocial.Domain.Profiles.Models;

public class Follower
{
    public Follower(Profile follower, Profile followed)
    {
        this.FollowerProfile = follower;
        this.FollowedProfile = followed;

        this.FollowerId = follower.Id;
        this.FollowedId = followed.Id;
    }

    private Follower(int followerId, int followedId)
    {
        this.FollowerId = followerId;
        this.FollowedId = followedId;

        this.FollowerProfile = default!;
        this.FollowedProfile = default!;
    }

    public Profile FollowerProfile { get; private set; }

    public int FollowerId { get; }

    public Profile FollowedProfile { get; private set; }

    public int FollowedId { get; }
}