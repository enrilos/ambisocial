namespace AmbiSocial.Application.Profiles.Queries.Common;

using Application.Common.Mapping;
using Domain.Profiles.Models;

public class ProfileResponseModel : IMapFrom<Profile>
{
    public int Id { get; private set; }

    public string UserName { get; private set; } = default!;
}