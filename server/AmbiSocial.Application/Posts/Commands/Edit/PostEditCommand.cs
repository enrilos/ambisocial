namespace AmbiSocial.Application.Posts.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;

using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Posts.Repositories;
using Domain.Profiles.Repositories;
using MediatR;

public class PostEditCommand : PostCommand<PostEditCommand>, IRequest<Result<int>>
{
    public class PostEditCommandHandler : IRequestHandler<PostEditCommand, Result<int>>
    {
        private readonly IPostDomainRepository postDomainRepository;
        private readonly IProfileDomainRepository profileDomainRepository;

        public PostEditCommandHandler(
            IPostDomainRepository postDomainRepository,
            IProfileDomainRepository profileDomainRepository)
        {
            this.postDomainRepository = postDomainRepository;
            this.profileDomainRepository = profileDomainRepository;
        }

        public async Task<Result<int>> Handle(PostEditCommand request, CancellationToken cancellationToken)
        {
            var post = await this.postDomainRepository.Find(request.Id, cancellationToken);

            if (post is null)
            {
                throw new NotFoundException(nameof(post), request.Id);
            }

            var profile = await this.profileDomainRepository.FindByUserName(request.AuthorUserName, cancellationToken);

            if (profile is null)
            {
                throw new NotFoundException(nameof(profile), request.Id);
            }

            post
                .UpdateDescription(request.Description)
                .UpdateAuthor(profile);

            await this.postDomainRepository.Save(post);

            return request.Id;
        }
    }
}