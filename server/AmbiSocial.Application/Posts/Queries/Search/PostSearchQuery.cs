namespace AmbiSocial.Application.Posts.Queries.Search;

using System.Threading;
using System.Threading.Tasks;

using Domain.Common;
using Domain.Posts.Models;
using Domain.Posts.Specifications.Posts;
using MediatR;

public class PostSearchQuery : IRequest<PostSearchResponseModel>
{
    private const int PerPage = 6;

    public string? Author { get; init; }

    public string? SortBy { get; init; }

    public string? Order { get; init; }

    public int Page { get; init; } = 1;

    public class PostSearchQueryHandler : IRequestHandler<PostSearchQuery, PostSearchResponseModel>
    {
        private readonly IPostQueryRepository postQueryRepository;

        public PostSearchQueryHandler(IPostQueryRepository postQueryRepository)
            => this.postQueryRepository = postQueryRepository;

        public async Task<PostSearchResponseModel> Handle(PostSearchQuery request, CancellationToken cancellationToken)
        {
            var specification = this.GetSpecification(request);

            var searchOrder = new PostSearchSortOrder(request.SortBy, request.Order);

            var skip = (request.Page - 1) * PerPage;

            var posts = await this.postQueryRepository.List(
                specification,
                searchOrder,
                skip,
                PerPage,
                cancellationToken);

            var totalPosts = await this.postQueryRepository.Total(
                specification,
                cancellationToken);

            var totalPages = (int)Math.Ceiling((double)totalPosts / PerPage);

            return new PostSearchResponseModel(posts, request.Page, totalPages);
        }

        private Specification<Post> GetSpecification(PostSearchQuery query)
            => new PostByProfileUserNameSpecification(query.Author);
    }
}