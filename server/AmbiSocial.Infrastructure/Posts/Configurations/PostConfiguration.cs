namespace AmbiSocial.Infrastructure.Posts.Configurations;

using Domain.Posts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(p => p.ImageUrl)
            .HasMaxLength(MaxUrlLength)
            .IsRequired();

        builder
            .Property(p => p.Description)
            .HasMaxLength(MaxDescriptionLength)
            .IsRequired(false);

        builder
            .HasOne(p => p.Profile)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.ProfileId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}