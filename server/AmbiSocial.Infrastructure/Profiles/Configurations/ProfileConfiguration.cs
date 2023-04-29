namespace AmbiSocial.Infrastructure.Profiles.Configurations;

using Domain.Profiles.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

public class ProfileConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.UserName)
            .IsUnique();

        builder
            .Property(x => x.UserName)
            .HasMaxLength(MaxNameLength)
            .IsRequired();

        builder
            .Property(x => x.AvatarUrl)
            .HasMaxLength(MaxUrlLength);

        builder
            .Property(x => x.Description)
            .HasMaxLength(MaxDescriptionLength);
    }
}