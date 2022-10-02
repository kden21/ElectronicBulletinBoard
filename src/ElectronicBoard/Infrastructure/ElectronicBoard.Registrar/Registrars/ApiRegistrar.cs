using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ElectronicBoard.Registrar.Registrars;

public static class ApiRegistrar
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo{Title = "Electronic Board Api", Version = "v1"});
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Documentation.xml"));
        });

        return services;
    }
}