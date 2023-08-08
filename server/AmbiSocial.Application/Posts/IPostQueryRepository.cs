namespace AmbiSocial.Application.Posts;

using AmbiSocial.Domain.Common;
using Common.Contracts;
using Domain.Posts.Models;
using Queries.Common;
using Queries.Search;

public interface IPostQueryRepository : IQueryRepository<Post>
{
    Task<PostResponseModel?> Details(int id, CancellationToken cancellationToken);

    Task<int> Total(
        Specification<Post> specification,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<PostResponseModel>> List(
        Specification<Post> specification,
        PostSearchSortOrder sortOrder,
        int skip,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);
}