namespace AmbiSocial.Application.Posts.Commands.Common;

using Application.Common;

public class PostCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public required string ImageUrl { get; init; }

    public required string ProfileUserName { get; init; }

    public required string Description { get; init; }
}