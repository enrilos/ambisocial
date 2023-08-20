namespace AmbiSocial.Web.Extensions;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwagger(
        this IApplicationBuilder app,
        IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app
                .UseSwagger()
                .UseSwaggerUI();
        }

        return app;
    }
}