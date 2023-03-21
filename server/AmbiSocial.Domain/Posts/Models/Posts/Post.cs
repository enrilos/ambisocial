namespace AmbiSocial.Domain.Posts.Models.Posts;

using Common;
using Common.Models;

public class Post : Entity<int>, IAggregateRoot
{
    internal Post()
    {
    }
}