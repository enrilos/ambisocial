namespace AmbiSocial.Application.Posts.Handlers;

using Common.Contracts;
using Common.Exceptions;
using Domain.Posts.Events;
using Domain.Posts.Repositories;

public class PostDeletedEventHandler : IEventHandler<PostDeletedEvent>
{
    private readonly IPostDomainRepository postDomainRepository;

    public PostDeletedEventHandler(IPostDomainRepository postDomainRepository)
        => this.postDomainRepository = postDomainRepository;

    public async Task Handle(PostDeletedEvent domainEvent)
    {
        var post = await this.postDomainRepository.Find(domainEvent.Id);

        if (post is null)
        {
            throw new NotFoundException(nameof(post), domainEvent.Id);
        }

        await this.postDomainRepository.Delete(post.Id);
    }
}