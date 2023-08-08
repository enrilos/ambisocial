namespace AmbiSocial.Domain.Common.Enums;

using Models;

public class Action : Enumeration
{
    public static readonly Action Read = new(1, nameof(Read));
    public static readonly Action Create = new(2, nameof(Create));
    public static readonly Action Update = new(3, nameof(Update));
    public static readonly Action Delete = new(4, nameof(Delete));

    private Action(int value)
        : this(value, FromValue<Action>(value).Name)
    {
    }

    private Action(int value, string name)
        : base(value, name)
    {
    }
}