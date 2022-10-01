using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.AppServices.Repositories.Review;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.AppServices.Services.Category;
using ElectronicBoard.AppServices.Services.Report;
using ElectronicBoard.AppServices.Services.Report.AdvtReport;
using ElectronicBoard.AppServices.Services.Report.CategoryReport;
using ElectronicBoard.AppServices.Services.Report.UserReport;
using ElectronicBoard.AppServices.Services.Review;
using ElectronicBoard.AppServices.Services.Review.AdvtReview;
using ElectronicBoard.AppServices.Services.Review.UserReview;
using ElectronicBoard.AppServices.Services.User;
using ElectronicBoard.AppServices.Shared.MapProfiles;
using ElectronicBoard.AppServices.Shared.MapProfiles.Report;
using ElectronicBoard.AppServices.Shared.MapProfiles.Review;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.DataAccess;
using ElectronicBoard.DataAccess.Interfaces;
using ElectronicBoard.DataAccess.Repositories;
using ElectronicBoard.DataAccess.Repositories.Report;
using ElectronicBoard.DataAccess.Repositories.Review;
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
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAdvtReviewRepository, AdvtReviewRepository>();
        services.AddScoped<IUserReviewRepository, UserReviewRepository>();
        services.AddScoped<IAdvtReportRepository, AdvtReportRepository>();
        services.AddScoped<IUserReportRepository, UserReportRepository>();
        services.AddScoped<ICategoryReportRepository, CategoryReportRepository>();
        
        services.AddScoped<IAdvtService, AdvtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAdvtReviewService, AdvtReviewService>();
        services.AddScoped<IUserReviewService, UserReviewService>();
        services.AddScoped<IAdvtReportService, AdvtReportService>();
        services.AddScoped<IUserReportService, UserReportService>();
        services.AddScoped<ICategoryReportService, CategoryReportService>();

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
            }
        );
        configuration.AssertConfigurationIsValid();

        return configuration;
    }
}