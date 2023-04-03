namespace AmbiSocial.Application.Posts.Commands.Edit;

using Common;
using FluentValidation;

public class PostEditCommandValidator : AbstractValidator<PostEditCommand>
{
    public PostEditCommandValidator()
        => this.Include(new PostCommandValidator<PostEditCommand>());
}