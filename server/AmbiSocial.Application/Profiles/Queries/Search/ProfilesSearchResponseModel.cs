namespace AmbiSocial.Application.Profiles.Queries.Search;

using System.Collections.Generic;

using Application.Common.Models;
using Common;

public class ProfilesSearchResponseModel : PaginatedResponseModel<ProfileResponseModel>
{
    public ProfilesSearchResponseModel(IEnumerable<ProfileResponseModel> models, int page, int totalPages)
        : base(models, page, totalPages)
    {
    }
}