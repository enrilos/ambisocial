namespace AmbiSocial.Application.Profiles.Commands.Common;

using Application.Common;

public class ProfileCommand<TCommand> : EntityCommand<int>
    where TCommand : EntityCommand<int>
{
    public string? AvatarUrl { get; init; }

    public string? Biography { get; init; }
}