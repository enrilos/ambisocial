namespace AmbiSocial.Application.Posts.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Application.Common.Contracts;
using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Posts.Repositories;
using Domain.Posts.Models;
using MediatR;

public class PostEditCommand : PostCommand<PostEditCommand>, IRequest<Result<int>>
{
    public class PostEditCommandHandler : IRequestHandler<PostEditCommand, Result<int>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IPostDomainRepository postDomainRepository;

        public PostEditCommandHandler(
            ICurrentUser currentUser,
            IPostDomainRepository postDomainRepository)
        {
            this.currentUser = currentUser;
            this.postDomainRepository = postDomainRepository;
        }

        public async Task<Result<int>> Handle(PostEditCommand request, CancellationToken cancellationToken)
        {
            Post? post = await this.postDomainRepository.Find(request.Id, cancellationToken);

            if (post is null)
            {
                throw new NotFoundException(nameof(Post), request.Id);
            }

            post.UpdateDescription(request.Description);

            await this.postDomainRepository.Save(post);

            return request.Id;
        }
    }
}