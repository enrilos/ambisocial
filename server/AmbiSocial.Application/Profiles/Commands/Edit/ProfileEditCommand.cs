namespace AmbiSocial.Application.Profiles.Commands.Edit;

using System.Threading;
using System.Threading.Tasks;
using Common;
using Application.Common.Contracts;
using Application.Common.Models;
using Domain.Common.Constants;
using Domain.Profiles.Models;
using Domain.Profiles.Repositories;
using MediatR;

public class ProfileEditCommand : ProfileCommand<ProfileEditCommand>, IRequest<Result<int>>
{
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
            Profile? profile = await this.profileDomainRepository.Find(this.currentUser.Id, cancellationToken);

            if (profile is null)
            {
                return Messages.NotFound(nameof(Profile));
            }

            profile.Update(request.AvatarUrl, request.Biography);

            await this.profileDomainRepository.Save(profile, cancellationToken);

            return profile.Id;
        }
    }
}