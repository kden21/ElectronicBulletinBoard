using AutoMapper;
using ElectronicBoard.AppServices.Shared.MapProfiles;
using ElectronicBoard.AppServices.Shared.MapProfiles.Report;
using ElectronicBoard.AppServices.Shared.MapProfiles.Review;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars;

public static class AutoMapperRegistrar
{
    public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(GetMapperConfiguration()));
        
        return services;
    }

    private static MapperConfiguration GetMapperConfiguration()
    {
        var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(new AdvtMapProfile());
                config.AddProfile(new UserMapProfile());
                config.AddProfile(new CategoryMapProfile());
                config.AddProfile(new AdvtReviewMapProfile());
                config.AddProfile(new UserReviewMapProfile());
                config.AddProfile(new AdvtReportMapProfile());
                config.AddProfile(new UserReportMapProfile());
                config.AddProfile(new CategoryReportMapProfile());
                config.AddProfile(new AccountMapProfile());
                config.AddProfile(new PhotoMapProfile());
            }
        );
        configuration.AssertConfigurationIsValid();

        return configuration;
    }
}