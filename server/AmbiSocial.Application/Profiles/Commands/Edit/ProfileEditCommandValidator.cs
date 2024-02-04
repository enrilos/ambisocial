namespace AmbiSocial.Application.Profiles.Commands.Edit;

using Common;
using FluentValidation;

public class ProfileEditCommandValidator : AbstractValidator<ProfileEditCommand>
{
    public ProfileEditCommandValidator()
        => this.Include(new ProfileCommandValidator<ProfileEditCommand>());
}