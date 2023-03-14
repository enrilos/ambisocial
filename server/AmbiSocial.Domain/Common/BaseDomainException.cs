namespace AmbiSocial.Domain.Common;

using System;

public abstract class BaseDomainException : Exception
{
    private string? error;

    public string Error
    {
        get => error ?? base.Message;
        set => error = value;
    }
}