namespace AmbiSocial.Domain.Profiles.Exceptions;

using Common;

public class InvalidFollowerException : BaseDomainException
{
    public InvalidFollowerException()
    {
    }

    public InvalidFollowerException(string error) => this.Error = error;
}