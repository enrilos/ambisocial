namespace AmbiSocial.Infrastructure.Posts.Configurations;

using Domain.Posts.Models.Posts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Domain.Common.Models.ModelConstants.Common;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.ImageUrl)
            .HasMaxLength(MaxUrlLength)
            .IsRequired();

        builder
            .Property(x => x.Description)
            .HasMaxLength(MaxDescriptionLength);

        builder
            .HasOne(x => x.Profile)
            .WithMany()
            .HasForeignKey("ProfileId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
    }
}