namespace AmbiSocial.Domain.Profiles.Factories;

using Common;
using Models;

public interface IProfileFactory : IFactory<Profile>
{
    IProfileFactory WithDescription(string description);

    IProfileFactory FromUserName(string userName);
}