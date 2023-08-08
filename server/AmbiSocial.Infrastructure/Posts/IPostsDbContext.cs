namespace AmbiSocial.Infrastructure.Posts;

using Common.Persistance;
using Domain.Posts.Models;
using Microsoft.EntityFrameworkCore;

internal interface IPostsDbContext : IDbContext
{
    DbSet<Post> Posts { get; }
}