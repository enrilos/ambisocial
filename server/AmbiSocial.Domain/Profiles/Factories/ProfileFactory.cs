namespace AmbiSocial.Domain.Profiles.Factories;

using Exceptions;
using Models;

public class ProfileFactory : IProfileFactory
{
    private string profileUserName = default!;
    private string profileDescription = default!;

    private bool isUserNameSet = false;

    public IProfileFactory WithDescription(string description)
    {
        this.profileDescription = description;

        return this;
    }

    public IProfileFactory FromUserName(string userName)
    {
        this.profileUserName = userName;
        this.isUserNameSet = true;

        return this;
    }

    public Profile Build()
    {
        if (!this.isUserNameSet)
        {
            throw new InvalidProfileException("Username is required");
        }

        return new Profile(this.profileUserName, this.profileDescription);
    }
}