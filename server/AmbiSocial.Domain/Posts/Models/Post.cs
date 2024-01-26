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

        this.RaiseEvent(new PostCreatedEvent(
            this.Id,
            this.ImageUrl,
            this.Description,
            this.Profile.UserName));
    }

    private Post(
        string imageUrl,
        string description)
    {
        this.ImageUrl = imageUrl;
        this.Description = description;

        this.Profile = default!;
    }

    public string ImageUrl { get; private set; }

    public string Description { get; private set; }

    public Profile Profile { get; private set; }

    public void Update(string description)
    {
        this.UpdateDescription(description);

        this.RaiseEvent(new PostUpdatedEvent(
            this.Id,
            this.Description));
    }

    public Post UpdateDescription(string description)
    {
        this.ValidateDescription(description);

        this.Description = description;

        return this;
    }

    public override void Delete(DateTime now)
    {
        base.Delete(now);

        this.RaiseEvent(new PostDeletedEvent(this.Id));
    }

    private void Validate(string imageUrl, string description, Profile profile)
    {
        if (imageUrl is not null)
        {
            Ensure.Url<InvalidPostException>(imageUrl);
        }

        this.ValidateDescription(description);

        Ensure.NotNull<InvalidProfileException>(profile);
    }

    private void ValidateDescription(string description)
    {
        Ensure.NotNullOrWhiteSpace<InvalidPostException>(description);

        Ensure.Range<InvalidPostException>(
                description,
                MinDescriptionLength,
                MaxDescriptionLength);
    }
}