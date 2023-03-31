namespace AmbiSocial.Application.Identity.Commands.Common;

public abstract class UserRequestModel
{
    protected internal UserRequestModel(string email, string userName, string password)
    {
        this.Email = email;
        this.UserName = userName;
        this.Password = password;
    }

    public string Email { get; }

    public string UserName { get; }

    public string Password { get; }
}