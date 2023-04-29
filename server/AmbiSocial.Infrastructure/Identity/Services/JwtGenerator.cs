namespace AmbiSocial.Infrastructure.Identity.Services;

using Application.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using static Domain.Common.Models.ModelConstants.Common;

internal class JwtGenerator : IJwtGenerator
{
    private readonly UserManager<User> userManager;
    private readonly ApplicationSettings applicationSettings;

    public JwtGenerator(
        UserManager<User> userManager,
        IOptions<ApplicationSettings> applicationSettings)
    {
        this.userManager = userManager;
        this.applicationSettings = applicationSettings.Value;
    }

    public async Task<string> Generate(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(this.applicationSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName!)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var isAdministrator = await this.userManager.IsInRoleAsync(user, AdministratorRoleName);

        if (isAdministrator)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, AdministratorRoleName));
        }

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var encryptedToken = tokenHandler.WriteToken(token);

        return encryptedToken;
    }
}