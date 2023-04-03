namespace AmbiSocial.Application.Posts.Queries.Details;

using System.Threading;
using System.Threading.Tasks;

using Common;
using MediatR;

public class PostDetailsQuery : IRequest<PostResponseModel?>
{
    public int Id { get; init; }

    public class PostDetailsQueryHandler : IRequestHandler<PostDetailsQuery, PostResponseModel?>
    {
        private readonly IPostQueryRepository postQueryRepository;

        public PostDetailsQueryHandler(IPostQueryRepository postQueryRepository)
            => this.postQueryRepository = postQueryRepository;

        public async Task<PostResponseModel?> Handle(PostDetailsQuery request, CancellationToken cancellationToken)
            => await this.postQueryRepository.Details(request.Id, cancellationToken);
    }
}