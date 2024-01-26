namespace AmbiSocial.Domain.Profiles.Repositories;

using Common;
using Models;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Profile?> FindByUserName(
        string userName,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteByUserName(
        string userName,
        CancellationToken cancellationToken = default);
}