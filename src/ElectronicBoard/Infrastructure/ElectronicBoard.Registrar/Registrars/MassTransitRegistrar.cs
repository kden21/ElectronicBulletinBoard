using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars;

public static class MassTransitRegistrar
{
    public static IServiceCollection AddRabbitMqMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq();
        });
        services.AddMassTransitHostedService();

        return services;
    }
}