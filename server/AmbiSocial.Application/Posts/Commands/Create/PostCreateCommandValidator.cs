namespace AmbiSocial.Application.Posts.Commands.Create;

using Common;
using FluentValidation;

public class PostCreateCommandValidator : AbstractValidator<PostCreateCommand>
{
    public PostCreateCommandValidator()
        => this.Include(new PostCommandValidator<PostCreateCommand>());
}