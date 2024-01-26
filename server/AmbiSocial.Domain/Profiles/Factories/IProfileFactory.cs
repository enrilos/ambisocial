namespace AmbiSocial.Domain.Profiles.Factories;

using Common;
using Models;

public interface IProfileFactory : IFactory<Profile>
{
    IProfileFactory WithAvatarUrl(string? avatarUrl);

    IProfileFactory WithBiography(string? biography);

    IProfileFactory WithUserName(string userName);
}