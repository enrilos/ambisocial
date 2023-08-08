namespace AmbiSocial.Infrastructure.Profiles.Configurations;

using Domain.Profiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class FollowerConfiguration : IEntityTypeConfiguration<Follower>
{
    public void Configure(EntityTypeBuilder<Follower> builder)
    {
        builder
            .HasKey(f => new { f.FollowerId, f.FollowedId });

        builder
            .HasOne(f => f.FollowerProfile)
            .WithMany(p => p.Followed)
            .HasForeignKey(f => f.FollowerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(f => f.FollowedProfile)
            .WithMany(p => p.Followers)
            .HasForeignKey(f => f.FollowedId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}