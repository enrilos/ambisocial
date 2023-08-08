namespace AmbiSocial.Domain.Common.Constants;

using Enums;

public static class Messages
{
    private const string DefaultModelName = "Model";

    public static string NotFound(string modelName = DefaultModelName)
        => $"Could not find ${modelName}";

    public static string NotApplicable(Action action, string modelName = DefaultModelName)
        => $"Unable to {action.Name} {modelName}";
}