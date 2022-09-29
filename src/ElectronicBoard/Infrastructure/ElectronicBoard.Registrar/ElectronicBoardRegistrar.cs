using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.AppServices.Shared.MapProfiles;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.DataAccess;
using ElectronicBoard.DataAccess.Interfaces;
using ElectronicBoard.DataAccess.Repositories;
using ElectronicBoard.DataAccess.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar;

public static class ElectronicBoardRegistrar
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddDbContext<ElectronicBoardContext>(
            (Action<IServiceProvider, DbContextOptionsBuilder>) ((sp, dbOptions) =>
                sp.GetRequiredService<IDbContextOptionsConfigurator<ElectronicBoardContext>>()
                    .Configure((DbContextOptionsBuilder<ElectronicBoardContext>) dbOptions)));
        services
            .AddSingleton<IDbContextOptionsConfigurator<ElectronicBoardContext>, ElectronicBoardContextConfiguration>();
        services.AddScoped(sp => (DbContext) sp.GetRequiredService<ElectronicBoardContext>());
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAdvtRepository, AdvtRepository>();
        services.AddScoped<IAdvtService, AdvtService>();
        
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AdvtMapProfile());
                config.AddProfile(new UserMapProfile());
            }
        );
        configuration.AssertConfigurationIsValid();

        return configuration;
    }
}