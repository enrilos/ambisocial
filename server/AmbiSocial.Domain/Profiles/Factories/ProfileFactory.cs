namespace AmbiSocial.Domain.Profiles.Factories;

using Exceptions;
using Models;

public class ProfileFactory : IProfileFactory
{
    private string profileUserName = default!;
    private string? profileAvatarUrl = default!;
    private string? profileDescription = default!;

    private bool hasUserName = false;

    public IProfileFactory WithAvatarUrl(string? avatarUrl)
    {
        this.profileAvatarUrl = avatarUrl;

        return this;
    }

    public IProfileFactory WithBiography(string? biography)
    {
        this.profileDescription = biography;

        return this;
    }

    public IProfileFactory WithUserName(string userName)
    {
        this.profileUserName = userName;
        this.hasUserName = true;

        return this;
    }

    public Profile Build()
    {
        bool hasFilledRequiredFields = this.hasUserName;

        if (!hasFilledRequiredFields)
        {
            throw new InvalidProfileException();
        }

        return new Profile(this.profileUserName, this.profileAvatarUrl, this.profileDescription);
    }
}