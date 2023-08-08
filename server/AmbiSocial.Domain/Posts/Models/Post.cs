namespace AmbiSocial.Domain.Posts.Models;

using Common;
using Common.Models;
using Events;
using Exceptions;
using Profiles.Exceptions;
using Profiles.Models;

using static Common.Models.ModelConstants.Common;

public class Post : Entity<int>, IAggregateRoot
{
    internal Post(
        string imageUrl,
        string description,
        Profile profile)
    {
        this.Validate(imageUrl, description, profile);

        this.ImageUrl = imageUrl;
        this.Description = description;
        this.Profile = profile;
        this.CreatedAt = DateTime.UtcNow;

        this.RaiseEvent(new PostCreatedEvent(
            this.ImageUrl,
            this.Description,
            this.Profile.UserName));
    }

    private Post(string imageUrl, string description)
    {
        this.ImageUrl = imageUrl;
        this.Description = description;
        this.CreatedAt = DateTime.UtcNow;

        this.Profile = default!;
    }

    public string ImageUrl { get; private set; }

    public string Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Profile Profile { get; private set; }

    public int ProfileId { get; private set; }

    public Post UpdateDescription(string description)
    {
        if (this.Description != description)
        {
            this.ValidateDescription(description);

            this.Description = description;

            this.RaiseEvent(new PostDescriptionUpdatedEvent(
                this.Id,
                this.Description));
        }

        return this;
    }

    public Post UpdateAuthor(Profile profile)
    {
        this.Profile = profile;
        this.ProfileId = profile.Id;

        return this;
    }

    private void Validate(string imageUrl, string description, Profile profile)
    {
        this.ValidateUrl(imageUrl);
        this.ValidateDescription(description);
        this.ValidateProfile(profile);
    }

    private void ValidateUrl(string url)
        => Guard.ForValidUrl<InvalidPostException>(
            url,
            nameof(this.ImageUrl));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidPostException>(
            description,
            MinDescriptionLength,
            MaxDescriptionLength,
            nameof(this.Description));

    private void ValidateProfile(Profile profile)
        => Guard.AgainstNull<InvalidProfileException>(
            profile,
            nameof(this.Profile));
}