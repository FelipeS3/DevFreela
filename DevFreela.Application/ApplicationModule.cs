using DevFreela.Application.Commands.InsertProject;
using DevFreela.Application.Models;
using DevFreela.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Application;

public static class ApplicationModule
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddHandlers()
            .AddValidation();
            
        return services;
    }

    private static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(config =>
            config.RegisterServicesFromAssemblyContaining<InsertProjectCommand>());

        services.AddTransient<IPipelineBehavior<InsertProjectCommand, ResultViewModel<int>>, ValidateInsertProjectCommandBehavior>();
        return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<InsertProjectCommand>();

        return services;
    }

}