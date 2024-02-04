namespace AmbiSocial.Application.Profiles.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Profiles.Events;
using Domain.Profiles.Repositories;
using Domain.Profiles.Models;

public class ProfileUpdatedEventHandler : IEventHandler<ProfileUpdatedEvent>
{
    private readonly IProfileDomainRepository profileDomainRepository;

    public ProfileUpdatedEventHandler(IProfileDomainRepository profileDomainRepository)
    {
        this.profileDomainRepository = profileDomainRepository;
    }

    public async Task Handle(ProfileUpdatedEvent domainEvent)
    {
        Profile? profile = await this.profileDomainRepository.Find(domainEvent.UserName);

        if (profile is null)
        {
            throw new NotFoundException(nameof(Profile), domainEvent.UserName);
        }

        profile.Update(domainEvent.AvatarUrl, domainEvent.Biography);

        await this.profileDomainRepository.Save(profile);
    }
}