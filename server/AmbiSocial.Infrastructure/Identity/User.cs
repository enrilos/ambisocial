namespace AmbiSocial.Infrastructure.Identity;

using Application.Identity;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser, IUser
{
    internal User(string email, string userName)
    {
        this.Email = email;
        this.UserName = userName;
    }
}