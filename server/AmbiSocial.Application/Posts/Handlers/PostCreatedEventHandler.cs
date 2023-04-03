namespace AmbiSocial.Application.Posts.Handlers;

using System.Threading.Tasks;

using Common.Contracts;
using Common.Exceptions;
using Domain.Posts.Events;
using Domain.Posts.Factories;
using Domain.Posts.Repositories;
using Domain.Profiles.Repositories;

public class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
{
    private readonly IPostFactory postFactory;
    private readonly IPostDomainRepository postDomainRepository;
    private readonly IProfileDomainRepository profileDomainRepository;

    public PostCreatedEventHandler(
        IPostFactory postFactory,
        IPostDomainRepository postDomainRepository,
        IProfileDomainRepository profileDomainRepository)
    {
        this.postFactory = postFactory;
        this.postDomainRepository = postDomainRepository;
        this.profileDomainRepository = profileDomainRepository;
    }

    public async Task Handle(PostCreatedEvent domainEvent)
    {
        var profile = await this.profileDomainRepository.FindByUserName(domainEvent.UserName);

        if (profile is null)
        {
            throw new NotFoundException(nameof(profile), domainEvent.UserName);
        }

        var post = this.postFactory
            .WithImageUrl(domainEvent.ImageUrl)
            .WithDescription(domainEvent.Description)
            .FromProfile(profile)
            .Build();

        await this.postDomainRepository.Save(post);
    }
}