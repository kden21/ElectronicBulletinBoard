using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars.StartupRegistrars;

public static class RegistrarStartupServices
{
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        ConfigurationManager configuration = builder.Configuration;
        IWebHostEnvironment environment = builder.Environment;

        builder.Services.AddApiServices()
            .AddDataAccessServices(configuration, environment)
            .AddAutoMapperService()
            .AddAppServices(configuration)
            .AddAuthServices(configuration)
            .AddRabbitMqMassTransit(configuration);
        builder.Services.AddCors();
        
        return builder;
    }
}