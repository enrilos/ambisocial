namespace AmbiSocial.Infrastructure.Profiles.Configurations;

using Domain.Profiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FollowerConfiguration : IEntityTypeConfiguration<Follower>
{
    public void Configure(EntityTypeBuilder<Follower> builder)
    {
        builder
            .HasKey(new string[] { "FollowerId", "FollowedId" });

        builder
            .HasOne(x => x.FollowerProfile)
            .WithMany()
            .HasForeignKey("FollowerId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.FollowedProfile)
            .WithMany()
            .HasForeignKey("FollowedId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        /*builder
            .HasKey(x => new { x.FollowerId, x.FollowedId });

        builder
            .HasOne(x => x.FollowerProfile)
            .WithMany(x => x.Following)
            .HasForeignKey(x => x.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(x => x.FollowedProfile)
            .WithMany(x => x.Followers)
            .HasForeignKey(x => x.FollowedId)
            .OnDelete(DeleteBehavior.Restrict);*/
    }
}