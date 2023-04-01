namespace AmbiSocial.Application.Profiles.Queries.Details;

using System.Threading;
using System.Threading.Tasks;

using MediatR;

public class ProfileDetailsQuery : IRequest<ProfileDetailsResponseModel>
{
    public string UserName { get; init; }

    public class ProfileDetailsQueryHandler : IRequestHandler<ProfileDetailsQuery, ProfileDetailsResponseModel>
    {
        private readonly IProfileQueryRepository profileQueryRepository;

        public ProfileDetailsQueryHandler(IProfileQueryRepository profileQueryRepository)
            => this.profileQueryRepository = profileQueryRepository;

        public async Task<ProfileDetailsResponseModel> Handle(ProfileDetailsQuery request, CancellationToken cancellationToken)
            => await this.profileQueryRepository.Details(request.UserName, cancellationToken);
    }
}