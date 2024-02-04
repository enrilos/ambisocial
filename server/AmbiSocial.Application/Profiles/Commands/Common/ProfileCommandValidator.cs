namespace AmbiSocial.Application.Profiles.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;

public class ProfileCommandValidator<TCommand> : AbstractValidator<ProfileCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public ProfileCommandValidator()
    {
        this.RuleFor(x => x.Biography)
            .MaximumLength(MaxDescriptionLength);
    }
}