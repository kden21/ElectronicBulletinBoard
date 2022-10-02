using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

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
            .AddAppServices();
            //.AddHandlerService();

       /* builder.WebHost.ConfigureKestrel(serverOptions =>
        {
            serverOptions.Limits.MaxRequestBodySize = 100_000_000;
            serverOptions.Limits.MaxRequestLineSize = 100_000_000;
            serverOptions.Limits.MaxRequestBufferSize = 100_000_000;
        });*/
        
        return builder;
    }
}