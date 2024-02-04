namespace AmbiSocial.Application.Posts.Handlers;

using System.Threading.Tasks;
using Common.Contracts;
using Common.Exceptions;
using Domain.Posts.Repositories;
using Domain.Posts.Events;
using Domain.Posts.Models;

public class PostUpdatedEventHandler : IEventHandler<PostUpdatedEvent>
{
    private readonly IPostDomainRepository postDomainRepository;

    public PostUpdatedEventHandler(IPostDomainRepository postDomainRepository)
    {
        this.postDomainRepository = postDomainRepository;
    }

    public async Task Handle(PostUpdatedEvent domainEvent)
    {
        Post? post = await this.postDomainRepository.Find(domainEvent.Id);

        if (post is null)
        {
            throw new NotFoundException(nameof(Post), domainEvent.Id);
        }

        post.Update(domainEvent.Description);

        await this.postDomainRepository.Save(post);
    }
}