namespace AmbiSocial.Domain.Profiles.Exceptions;

using Common;

public class InvalidProfileException : BaseDomainException
{
    public InvalidProfileException()
    {
    }

    public InvalidProfileException(string error) => this.Error = error;
}