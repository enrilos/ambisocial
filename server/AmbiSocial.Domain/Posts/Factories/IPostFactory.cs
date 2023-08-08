namespace AmbiSocial.Domain.Posts.Factories;

using Common;
using Models;
using Profiles.Models;

public interface IPostFactory : IFactory<Post>
{
    IPostFactory WithImageUrl(string imageUrl);

    IPostFactory WithDescription(string description);

    IPostFactory FromProfile(Profile profile);
}
