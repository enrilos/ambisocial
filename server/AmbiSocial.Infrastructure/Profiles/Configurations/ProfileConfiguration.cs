namespace AmbiSocial.Infrastructure.Profiles.Configurations;

using Identity;
using Domain.Profiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .HasIndex(p => p.UserName)
            .IsUnique();

        builder
            .Property(p => p.UserName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(p => p.AvatarUrl)
            .HasMaxLength(MaxUrlLength)
            .IsRequired(false);

        builder
            .Property(p => p.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired(false);

        builder
            .HasOne<User>()
            .WithOne()
            .HasForeignKey<Profile>(p => p.UserName)
            .HasPrincipalKey<User>(u => u.UserName)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}