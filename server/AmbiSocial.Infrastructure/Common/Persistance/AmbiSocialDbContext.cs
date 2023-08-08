namespace AmbiSocial.Infrastructure.Common.Persistance;

using System.Reflection;

using Domain.Posts.Models;
using Domain.Profiles.Models;
using Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Posts;
using Profiles;

internal class AmbiSocialDbContext : IdentityDbContext<User>,
    IProfilesDbContext,
    IPostsDbContext
{
    public AmbiSocialDbContext(DbContextOptions<AmbiSocialDbContext> options)
        : base(options)
    {
    }

    public DbSet<Profile> Profiles { get; set; } = default!;

    public DbSet<Follower> Followers { get; set; } = default!;

    public DbSet<Post> Posts { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}