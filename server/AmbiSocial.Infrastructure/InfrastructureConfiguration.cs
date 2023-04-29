namespace AmbiSocial.Infrastructure;

using System.Text;

using Application.Common;
using Application.Identity;
using Application.Posts;
using Application.Profiles;
using Common.Events;
using Common.Extensions;
using Common.Persistance;
using Domain.Posts.Repositories;
using Domain.Profiles.Repositories;
using Identity;
using Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Posts;
using Posts.Repositories;
using Profiles;
using Profiles.Repositories;

using static Domain.Common.Models.ModelConstants.Identity;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDatabase(configuration)
            .AddRepositories()
            .AddIdentity(configuration)
            .AddTransient<IEventDispatcher, EventDispatcher>();

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        => services
            .AddDbContext<AmbiSocialDbContext>(options => options
                .UseNpgsql(
                    configuration.GetDefaultConnectionString(),
                    npgSql => npgSql.MigrationsAssembly(typeof(AmbiSocialDbContext).Assembly.FullName)))
            .AddScoped<IProfilesDbContext>(provider => provider
                .GetService<AmbiSocialDbContext>()!)
            .AddScoped<IPostsDbContext>(provider => provider
                .GetService<AmbiSocialDbContext>()!)
            .AddTransient<IDbInitializer, AmbiSocialDbInitializer>();

    // TODO: Use Scrutor
    private static IServiceCollection AddRepositories(this IServiceCollection services)
        => services
            .AddTransient<IProfileDomainRepository, ProfileRepository>()
            .AddTransient<IProfileQueryRepository, ProfileRepository>()
            .AddTransient<IPostDomainRepository, PostRepository>()
            .AddTransient<IPostQueryRepository, PostRepository>();

    private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<IIdentity, IdentityService>()
            .AddTransient<IJwtGenerator, JwtGenerator>()
            .AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredLength = MinPasswordLength;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AmbiSocialDbContext>();

        var secret = configuration
            .GetSection(nameof(ApplicationSettings))
            .GetValue<string>(nameof(ApplicationSettings.Secret))!;

        var key = Encoding.ASCII.GetBytes(secret);

        services
            .AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        return services;
    }
}