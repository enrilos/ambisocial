namespace AmbiSocial.Application.Posts.Commands.Common;

using Application.Common;

public class PostCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public required string ImageUrl { get; init; }

    public required string AuthorUserName { get; init; }

    public string? Description { get; init; }
}