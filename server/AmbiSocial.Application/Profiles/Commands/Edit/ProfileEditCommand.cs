namespace AmbiSocial.Application.Profiles.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;

using Common;
using Common.Contracts;
using Common.Models;
using Domain.Profiles.Repositories;
using MediatR;

public class ProfileEditCommand : EntityCommand<int>, IRequest<Result<int>>
{
    public string Description { get; init; } = default!;

    public class ProfileEditCommandHandler : IRequestHandler<ProfileEditCommand, Result<int>>
    {
        private readonly ICurrentUser currentUser;
        private readonly IProfileDomainRepository profileDomainRepository;

        public ProfileEditCommandHandler(ICurrentUser currentUser, IProfileDomainRepository profileDomainRepository)
        {
            this.currentUser = currentUser;
            this.profileDomainRepository = profileDomainRepository;
        }

        public async Task<Result<int>> Handle(ProfileEditCommand request, CancellationToken cancellationToken)
        {
            var profile = await this.profileDomainRepository
                .FindByUserName(this.currentUser.UserName, cancellationToken);

            if (request.Id != profile.Id)
            {
                return "Illegal modification of a profile";
            }

            profile.UpdateDescription(request.Description);

            await this.profileDomainRepository.Save(profile, cancellationToken);

            return profile.Id;
        }
    }
}