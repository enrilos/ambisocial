namespace AmbiSocial.Application.Common.Contracts;

public interface ICurrentUser
{
    int Id { get; }

    string Name { get; }
}
