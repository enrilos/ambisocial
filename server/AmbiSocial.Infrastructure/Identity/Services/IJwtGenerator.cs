namespace AmbiSocial.Infrastructure.Identity.Services;

public interface IJwtGenerator
{
    Task<string> Generate(User user);
}