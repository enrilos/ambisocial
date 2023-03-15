﻿namespace AmbiSocial.Domain.Common.Models;

using System;

public static class Guard
{
    public static void AgainstNullOrEmpty<TException>(string value, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            return;
        }

        ThrowException<TException>($"{name} cannot be null or empty.");
    }

    public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstNullOrEmpty<TException>(value, name);

        if (minLength <= value.Length && value.Length <= maxLength)
        {
            return;
        }

        ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
    }

    public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
        where TException : BaseDomainException, new()
    {
        if (min <= number && number <= max)
        {
            return;
        }

        ThrowException<TException>($"{name} must be between {min} and {max}.");
    }

    public static void ForValidUrl<TException>(string url, string name = "Value")
        where TException : BaseDomainException, new()
    {
        AgainstNullOrEmpty<TException>(url, name);

        if (url.Length <= ModelConstants.Common.MaxUrlLength &&
            Uri.IsWellFormedUriString(url, UriKind.Absolute))
        {
            return;
        }

        ThrowException<TException>($"{name} must be a valid URL.");
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