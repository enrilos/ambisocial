namespace AmbiSocial.Domain.Profiles.Repositories;

using Common;
using Models;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile?> Find(
        int id,
        CancellationToken cancellationToken = default);

    Task<Profile?> Find(
        string userName,
        CancellationToken cancellationToken = default);

    Task<bool> Delete(
        string userName,
        CancellationToken cancellationToken = default);
}