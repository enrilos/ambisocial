namespace AmbiSocial.Application.Identity.Commands.Register;

using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;
using static Domain.Common.Models.ModelConstants.Identity;

public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
{
    public UserRegisterCommandValidator()
    {
        this.RuleFor(x => x.Email)
            .MinimumLength(MinEmailLength)
            .MaximumLength(MaxEmailLength)
            .EmailAddress()
            .NotEmpty();

        this.RuleFor(x => x.UserName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        this.RuleFor(x => x.Password)
            .MinimumLength(MinPasswordLength)
            .MaximumLength(MaxPasswordLength)
            .NotEmpty();

        this.RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password)
            .WithMessage("Passwords do not match")
            .NotEmpty();
    }
}