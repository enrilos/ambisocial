namespace AmbiSocial.Application;

using Common;
using Common.Behaviors;
using Common.Contracts;
using Common.Mapping;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
        => services
            .Configure<ApplicationSettings>(
                configuration.GetSection(nameof(ApplicationSettings)),
                options => options.BindNonPublicProperties = true)
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyPointer).Assembly))
            .AddEventHandlers()
            .AddAutoMapperProfile()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

    private static IServiceCollection AddEventHandlers(
        this IServiceCollection services)
        => services
            .Scan(scan => scan
                .FromAssemblyOf<AssemblyPointer>()
                .AddClasses(cls => cls
                    .AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

    private static IServiceCollection AddAutoMapperProfile(
        this IServiceCollection services)
        => services
            .AddAutoMapper(
                (_, config) => config
                    .AddProfile(new MappingProfile(typeof(AssemblyPointer).Assembly)),
                typeof(AssemblyPointer).Assembly);
}