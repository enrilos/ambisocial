namespace AmbiSocial.Domain.Common.Models;

using System;

public static class Guard
{
    private const string DefaultValueName = "Value";
    private const string OutOfRangeExceptionTemplate = "{0} must be between {1} and {2}";

    public static void AgainstNull<TException>(object value, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        if (value is not null)
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null");
    }

    public static void AgainstNullOrEmpty<TException>(string value, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null or empty");
    }

    public static void ForStringLength<TException>(string value, int min, int max, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        AgainstNullOrEmpty<TException>(value, name);

        if (min <= value.Length && value.Length <= max)
        {
            return;
        }

        ThrowException<TException>($"{string.Format(OutOfRangeExceptionTemplate, name, min, max)} characters long");
    }

    public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>(string.Format(OutOfRangeExceptionTemplate, name, min, max));
    }

    public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>(string.Format(OutOfRangeExceptionTemplate, name, min, max));
    }

    public static void ForValidUrl<TException>(string url, string name = DefaultValueName)
        where TException : BaseDomainException, new()
    {
        AgainstNullOrEmpty<TException>(url, name);

        if (url.Length <= ModelConstants.Common.MaxUrlLength &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }

        ThrowException<TException>($"{name} must be a valid URL");
    }

    private static void ThrowException<TException>(string message)
        where TException : BaseDomainException, new()
    {
        var exception = new TException
        {
            Error = message
        };

        throw exception;
    }
}