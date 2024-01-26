namespace AmbiSocial.Domain.Posts.Factories;

using Exceptions;
using Models;
using Profiles.Models;

public class PostFactory : IPostFactory
{
    private string imageUrl = default!;
    private string description = default!;
    private Profile profile = default!;

    private bool hasDescription = false;
    private bool hasProfile = false;

    public IPostFactory WithImage(string imageUrl)
    {
        this.imageUrl = imageUrl;

        return this;
    }

    public IPostFactory WithDescription(string description)
    {
        this.description = description;
        this.hasDescription = true;

        return this;
    }

    public IPostFactory ForProfile(Profile profile)
    {
        this.profile = profile;
        this.hasProfile = true;

        return this;
    }

    public Post Build()
    {
        bool hasFilledRequiredFields = this.hasDescription && this.hasProfile;

        if (!hasFilledRequiredFields)
        {
            throw new InvalidPostException();
        }

        return new Post(
            this.imageUrl,
            this.description,
            this.profile);
    }
}