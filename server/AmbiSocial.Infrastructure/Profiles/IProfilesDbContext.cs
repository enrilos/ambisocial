namespace AmbiSocial.Infrastructure.Profiles;

using Common.Persistance;
using Domain.Profiles.Models;
using Microsoft.EntityFrameworkCore;

internal interface IProfilesDbContext : IDbContext
{
    DbSet<Profile> Profiles { get; }

    DbSet<Follower> Followers { get; }
}