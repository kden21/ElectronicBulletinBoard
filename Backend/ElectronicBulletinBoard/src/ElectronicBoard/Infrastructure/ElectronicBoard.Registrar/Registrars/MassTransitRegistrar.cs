using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars;

public static class MassTransitRegistrar
{
    private static bool _isContainer;
    private static string _containerStringVariable = "DOTNET_RUNNING_IN_CONTAINER";
    private static string _connectionStringLocal = "RabbitMqLocal";
    private static string _connectionStringDocker = "RabbitMqDocker";

    public static IServiceCollection AddRabbitMqMassTransit(this IServiceCollection services, IConfiguration configuration)
    {
        bool.TryParse(Environment.GetEnvironmentVariable(_containerStringVariable), out _isContainer);

        var rabbiMqConnectionString = _isContainer ? configuration.GetConnectionString(_connectionStringDocker) : configuration.GetConnectionString(_connectionStringLocal);

        services.AddMassTransit(configuration =>
        {
            configuration.UsingRabbitMq((_, config) =>
                {
                    config.Host(rabbiMqConnectionString);
                });
        });
        services.AddMassTransitHostedService();

        return services;
    }
}