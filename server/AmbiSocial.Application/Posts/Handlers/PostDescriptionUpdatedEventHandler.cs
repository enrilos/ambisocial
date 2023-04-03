namespace AmbiSocial.Application.Posts.Handlers;

using Common.Contracts;
using Common.Exceptions;
using Domain.Posts.Events;
using Domain.Posts.Repositories;

public class PostDescriptionUpdatedEventHandler : IEventHandler<PostDescriptionUpdatedEvent>
{
    private readonly IPostDomainRepository postDomainRepository;

    public PostDescriptionUpdatedEventHandler(IPostDomainRepository postDomainRepository)
        => this.postDomainRepository = postDomainRepository;


    public async Task Handle(PostDescriptionUpdatedEvent domainEvent)
    {
        var post = await this.postDomainRepository.Find(domainEvent.Id);

        if (post is null)
        {
            throw new NotFoundException(nameof(post), domainEvent.Id);
        }

        post.UpdateDescription(domainEvent.Description);

        await this.postDomainRepository.Save(post);
    }
}