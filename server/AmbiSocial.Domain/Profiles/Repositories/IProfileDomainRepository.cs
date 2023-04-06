namespace AmbiSocial.Domain.Profiles.Repositories;

using Common;
using Models;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile?> FindByUserName(
        string userName,
        CancellationToken cancellationToken = default);
}