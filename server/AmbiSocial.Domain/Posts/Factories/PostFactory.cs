namespace AmbiSocial.Domain.Posts.Factories;

using Exceptions;
using Models.Posts;
using Profiles.Models;

public class PostFactory : IPostFactory
{
    private string postImageUrl = default!;
    private string postDescription = default!;
    private Profile postProfile = default!;

    private bool isImageUrlSet = false;
    private bool isProfileSet = false;

    public IPostFactory WithImageUrl(string imageUrl)
    {
        this.postImageUrl = imageUrl;
        this.isImageUrlSet = true;

        return this;
    }

    public IPostFactory WithDescription(string description)
    {
        this.postDescription = description;
        return this;
    }

    public IPostFactory FromProfile(Profile profile)
    {
        this.postProfile = profile;
        this.isProfileSet = true;

        return this;
    }

    public Post Build()
    {
        bool areRequiredFieldsSet = this.isImageUrlSet && this.isProfileSet;

        if (!areRequiredFieldsSet)
        {
            throw new InvalidPostException("Image and profile must have a value");
        }

        return new Post(
            this.postImageUrl,
            this.postDescription,
            this.postProfile);
    }
}