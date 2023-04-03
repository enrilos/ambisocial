namespace AmbiSocial.Application.Posts.Commands.Create;

using System.Threading;
using System.Threading.Tasks;

using Application.Common.Exceptions;
using Application.Common.Models;
using Common;
using Domain.Posts.Factories;
using Domain.Posts.Repositories;
using Domain.Profiles.Repositories;
using MediatR;

public class PostCreateCommand : PostCommand<PostCreateCommand>, IRequest<Result<int>>
{
    public class PostCreateCommandHandler : IRequestHandler<PostCreateCommand, Result<int>>
    {
        private readonly IPostFactory postFactory;
        private readonly IProfileDomainRepository profileDomainRepository;
        private readonly IPostDomainRepository postDomainRepository;

        public PostCreateCommandHandler(
            IPostFactory postFactory,
            IProfileDomainRepository profileDomainRepository,
            IPostDomainRepository postDomainRepository)
        {
            this.postFactory = postFactory;
            this.profileDomainRepository = profileDomainRepository;
            this.postDomainRepository = postDomainRepository;
        }

        public async Task<Result<int>> Handle(PostCreateCommand request, CancellationToken cancellationToken)
        {
            var profile = await this.profileDomainRepository
                .FindByUserName(request.AuthorUserName, cancellationToken);

            if (profile is null)
            {
                throw new NotFoundException(nameof(profile), request.AuthorUserName);
            }

            var post = this.postFactory
                .WithImageUrl(request.ImageUrl)
                .WithDescription(request.Description)
                .FromProfile(profile)
                .Build();

            await this.postDomainRepository.Save(post, cancellationToken);

            return post.Id;
        }
    }
}