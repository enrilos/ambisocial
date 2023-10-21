namespace AmbiSocial.Domain.Common.Models;

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

public static class Ensure
{
    private const string DefaultParamName = "Value";
    private const string RangeConstraintTemplate = "{0} must be between {1} and {2}";

    public static void NotNull<TException>(
        object value,
        [CallerArgumentExpression("value")] string name = DefaultParamName)
        where TException : BaseDomainException, new()
    {
        if (value is not null)
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null");
    }

    public static void NotNullOrWhiteSpace<TException>(
        string value,
        [CallerArgumentExpression("value")] string name = DefaultParamName)
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null or whitespace");
    }

    public static void Range<TException>(
        string value,
        int minLength,
        int maxLength,
        [CallerArgumentExpression("value")] string name = DefaultParamName)
        where TException : BaseDomainException, new()
    {
        NotNullOrWhiteSpace<TException>(value, name);

        if (minLength <= value.Length && value.Length <= maxLength)
        {
            return;
        }

        ThrowException<TException>($"{string.Format(RangeConstraintTemplate, name, minLength, maxLength)} characters long");
    }

    public static void Range<TNumber, TException>(
        TNumber value,
        TNumber min,
        TNumber max,
        [CallerArgumentExpression("value")] string name = DefaultParamName)
        where TNumber : INumber<TNumber>
        where TException : BaseDomainException, new()
    {
        if (min <= value && value <= max)
        {
            return;
        }

        ThrowException<TException>(string.Format(RangeConstraintTemplate, name, min, max));
    }

    public static void Url<TException>(
        string url,
        [CallerArgumentExpression("url")] string name = DefaultParamName)
        where TException : BaseDomainException, new()
    {
        NotNullOrWhiteSpace<TException>(url, name);

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
        TException exception = new()
        {
            Error = message
        };

        throw exception;
    }
}