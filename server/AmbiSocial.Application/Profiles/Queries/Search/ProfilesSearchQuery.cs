namespace AmbiSocial.Application.Profiles.Queries.Search;

using System.Threading;
using System.Threading.Tasks;

using Domain.Common;
using Domain.Profiles.Models;
using Domain.Profiles.Specifications;
using MediatR;

public class ProfilesSearchQuery : IRequest<ProfilesSearchResponseModel>
{
    private const int PerPage = 9;

    public string UserName { get; init; }

    public int Page { get; init; } = 1;

    public class ProfileSearchQueryHandler : IRequestHandler<ProfilesSearchQuery, ProfilesSearchResponseModel>
    {
        private readonly IProfileQueryRepository profileQueryRepository;

        public ProfileSearchQueryHandler(IProfileQueryRepository profileQueryRepository)
            => this.profileQueryRepository = profileQueryRepository;

        public async Task<ProfilesSearchResponseModel> Handle(ProfilesSearchQuery request, CancellationToken cancellationToken)
        {
            var specification = this.GetSpecification(request);
            var skip = (request.Page - 1) * PerPage;

            var profiles = await this.profileQueryRepository.List(
                specification,
                skip,
                PerPage,
                cancellationToken);

            var total = await this.profileQueryRepository.Total(specification, cancellationToken);

            var pages = (int)Math.Ceiling((double)(total / PerPage));

            return new ProfilesSearchResponseModel(profiles, request.Page, pages);
        }

        private Specification<Profile> GetSpecification(
            ProfilesSearchQuery request)
            => new ProfileByUserNameSpecification(request.UserName);
    }
}