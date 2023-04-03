namespace AmbiSocial.Application.Posts.Commands.Common;

using Application.Common;
using FluentValidation;

using static Domain.Common.Models.ModelConstants.Common;

public class PostCommandValidator<TCommand> : AbstractValidator<PostCommand<TCommand>>
    where TCommand : EntityCommand<int>
{
    public PostCommandValidator()
    {
        this.RuleFor(x => x.ImageUrl)
            .MaximumLength(MaxUrlLength)
            .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
            .WithMessage("{PropertyName} must be a valid url")
            .NotEmpty();

        this.RuleFor(x => x.Description)
            .MaximumLength(MaxDescriptionLength);

        this.RuleFor(x => x.AuthorUserName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
    }
}