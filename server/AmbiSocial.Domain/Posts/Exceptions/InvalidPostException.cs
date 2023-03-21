namespace AmbiSocial.Domain.Posts.Exceptions;

using Common;

public class InvalidPostException : BaseDomainException
{
    public InvalidPostException()
    {
    }

    public InvalidPostException(string error) => this.Error = error;
}