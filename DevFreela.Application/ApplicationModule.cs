using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddService()
            .AddHandlers();
            
        return services;
    }

    private static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IProjectServices, ProjectServices>();
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());
        return services;
    }
}