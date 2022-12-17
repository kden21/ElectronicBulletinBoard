using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars;

public static class MassTransitRegistrar
{
    public static IServiceCollection AddRabbitMqMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(configuration =>
        {
            configuration.UsingRabbitMq((_, config) =>
                {
                    config.Host("amqp://guest:guest@rabbitmq:5672");
                });
        });
        services.AddMassTransitHostedService();

        return services;
    }
}