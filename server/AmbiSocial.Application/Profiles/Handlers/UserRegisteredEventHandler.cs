namespace AmbiSocial.Application.Profiles.Handlers;

using System.Threading.Tasks;

using Common.Contracts;
using Domain.Identity.Events;
using Domain.Profiles.Factories;
using Domain.Profiles.Repositories;

using static Domain.Common.Models.ModelConstants.Identity;

public class UserRegisteredEventHandler : IEventHandler<UserRegisteredEvent>
{
    private readonly IProfileFactory profileFactory;
    private readonly IProfileDomainRepository profileDomainRepository;

    public UserRegisteredEventHandler(IProfileFactory profileFactory, IProfileDomainRepository profileRepository)
    {
        this.profileFactory = profileFactory;
        this.profileDomainRepository = profileRepository;
    }

    public async Task Handle(UserRegisteredEvent domainEvent)
    {
        var profile = this.profileFactory
            .WithDescription(DefaultDescription)
            .FromUserName(domainEvent.UserName)
            .Build();

        await this.profileDomainRepository.Save(profile);
    }
}