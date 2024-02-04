namespace AmbiSocial.Application.Profiles.Handlers;

using System.Threading.Tasks;
using Domain.Profiles.Repositories;
using Common.Contracts;
using Domain.Profiles.Events;
using Domain.Profiles.Factories;
using Domain.Profiles.Models;

public class ProfileCreatedEventHandler : IEventHandler<ProfileCreatedEvent>
{
    private readonly IProfileFactory profileFactory;
    private readonly IProfileDomainRepository profileDomainRepository;

    public ProfileCreatedEventHandler(
        IProfileFactory profileFactory,
        IProfileDomainRepository profileDomainRepository)
    {
        this.profileFactory = profileFactory;
        this.profileDomainRepository = profileDomainRepository;
    }

    public async Task Handle(ProfileCreatedEvent domainEvent)
    {
        Profile profile = this.profileFactory
            .WithAvatarUrl(domainEvent.AvatarUrl)
            .WithBiography(domainEvent.Biography)
            .WithUserName(domainEvent.UserName)
            .Build();

        await this.profileDomainRepository.Save(profile);
    }
}