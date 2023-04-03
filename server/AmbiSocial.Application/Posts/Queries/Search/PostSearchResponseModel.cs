namespace AmbiSocial.Application.Posts.Queries.Search;

using System.Collections.Generic;

using AmbiSocial.Application.Common.Models;
using Common;

public class PostSearchResponseModel : PaginatedResponseModel<PostResponseModel>
{
    public PostSearchResponseModel(
        IEnumerable<PostResponseModel> models,
        int page,
        int totalPages)
        : base(models, page, totalPages)
    {
    }
}