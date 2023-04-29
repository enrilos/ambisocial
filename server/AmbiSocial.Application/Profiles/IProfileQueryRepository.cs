namespace AmbiSocial.Application.Profiles;

using AmbiSocial.Domain.Common;
using Common.Contracts;
using Domain.Profiles.Models;
using Queries.Common;
using Queries.Details;

public interface IProfileQueryRepository : IQueryRepository<Profile>
{
    Task<ProfileDetailsResponseModel?> Details(
        string userName,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<ProfileResponseModel>> List(
        Specification<Profile> specification,
        int skip,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default);

    Task<int> Total(
        Specification<Profile> specification,
        CancellationToken cancellationToken = default);
}