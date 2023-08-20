namespace AmbiSocial.Web;

using Microsoft.Extensions.DependencyInjection;

public static class WebConfiguration
{
    public static IServiceCollection AddWebComponents(this IServiceCollection services)
    {
        services
            .AddSwaggerGen()
            .AddControllers();

        return services;
    }
}