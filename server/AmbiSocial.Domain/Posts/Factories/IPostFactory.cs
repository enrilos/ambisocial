namespace AmbiSocial.Domain.Posts.Factories;

using Common;
using Models;
using Profiles.Models;

public interface IPostFactory : IFactory<Post>
{
    IPostFactory WithImage(string url);

    IPostFactory WithDescription(string description);

    IPostFactory ForProfile(Profile profile);
}
