namespace AmbiSocial.Domain.Posts.Models.Posts;

using Common;
using Common.Models;
using Events;
using Exceptions;
using Profiles.Models;

using static Common.Models.ModelConstants.Common;

public class Post : Entity<int>, IAggregateRoot
{
    internal Post(string imageUrl, string description, Profile profile)
    {
        this.Validate(imageUrl, description);

        this.ImageUrl = imageUrl;
        this.Description = description;
        this.Profile = profile;
        this.Date = DateTime.UtcNow;

        this.RaiseEvent(new PostCreatedEvent(
            this.ImageUrl,
            this.Description));
    }

    public string ImageUrl { get; private set; }

    public string Description { get; private set; }

    public DateTime Date { get; private set; }

    public Profile Profile { get; private set; }

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

    public Post UpdateProfile(Profile profile)
    {
        this.Profile = profile;

        return this;
    }

    private void Validate(string imageUrl, string description)
    {
        this.ValidateUrl(imageUrl);
        this.ValidateDescription(description);
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
}