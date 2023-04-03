namespace AmbiSocial.Application.Posts.Commands.Delete;

using System.Threading;
using System.Threading.Tasks;

using Application.Common;
using Application.Common.Models;
using Domain.Posts.Repositories;
using MediatR;

public class PostDeleteCommand : EntityCommand<int>, IRequest<Result>
{
    public class PostDeleteCommandHandler : IRequestHandler<PostDeleteCommand, Result>
    {
        private readonly IPostDomainRepository postDomainRepository;

        public PostDeleteCommandHandler(IPostDomainRepository postDomainRepository)
            => this.postDomainRepository = postDomainRepository;

        public async Task<Result> Handle(PostDeleteCommand request, CancellationToken cancellationToken)
            => await this.postDomainRepository.Delete(request.Id, cancellationToken);
    }
}