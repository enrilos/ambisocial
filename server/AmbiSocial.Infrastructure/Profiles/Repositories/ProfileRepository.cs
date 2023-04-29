namespace AmbiSocial.Infrastructure.Profiles.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Application.Profiles;
using Application.Profiles.Queries.Common;
using Application.Profiles.Queries.Details;
using Common.Events;
using Common.Repositories;
using Domain.Common;
using Domain.Profiles.Models;
using Domain.Profiles.Repositories;
using Microsoft.EntityFrameworkCore;

internal class ProfileRepository : DataRepository<IProfilesDbContext, Profile>,
    IProfileDomainRepository,
    IProfileQueryRepository
{
    public ProfileRepository(
        IProfilesDbContext db,
        AutoMapper.IMapper mapper,
        IEventDispatcher eventDispatcher)
        : base(db, mapper, eventDispatcher)
    {
    }

    public async Task<ProfileDetailsResponseModel?> Details(string userName, CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<ProfileDetailsResponseModel>(this
                .AllAsNoTracking()
                .Where(x => x.UserName == userName))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Profile?> FindByUserName(string userName, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(x => x.UserName == userName)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IEnumerable<ProfileResponseModel>> List(
        Specification<Profile> specification,
        int skip,
        int take = int.MaxValue,
        CancellationToken cancellationToken = default)
        => await this.Mapper
            .ProjectTo<ProfileResponseModel>(this
                .Query(specification)
                .Skip(skip)
                .Take(take))
            .ToListAsync(cancellationToken);

    public async Task<int> Total(Specification<Profile> specification, CancellationToken cancellationToken = default)
        => await this.Query(specification).CountAsync();

    private IQueryable<Profile> Query(Specification<Profile> specification)
        => this.AllAsNoTracking().Where(specification);
}