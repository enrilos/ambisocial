namespace AmbiSocial.Application.Profiles.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Profiles.Events;
using Domain.Profiles.Repositories;
using Domain.Profiles.Models;

public class ProfileDeletedEventHandler : IEventHandler<ProfileDeletedEvent>
{
    private readonly IProfileDomainRepository profileDomainRepository;

    public ProfileDeletedEventHandler(IProfileDomainRepository profileDomainRepository)
    {
        this.profileDomainRepository = profileDomainRepository;
    }

    public async Task Handle(ProfileDeletedEvent domainEvent)
    {
        Profile? profile = await this.profileDomainRepository.Find(domainEvent.UserName);

        if (profile is null)
        {
            throw new NotFoundException(nameof(Profile), domainEvent.UserName);
        }

        await this.profileDomainRepository.Delete(domainEvent.UserName);
    }
}