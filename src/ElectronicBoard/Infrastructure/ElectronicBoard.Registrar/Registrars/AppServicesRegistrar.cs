using ElectronicBoard.AppServices.Services.Account;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.AppServices.Services.Category;
using ElectronicBoard.AppServices.Services.Report.AdvtReport;
using ElectronicBoard.AppServices.Services.Report.CategoryReport;
using ElectronicBoard.AppServices.Services.Report.UserReport;
using ElectronicBoard.AppServices.Services.Review.AdvtReview;
using ElectronicBoard.AppServices.Services.Review.UserReview;
using ElectronicBoard.AppServices.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace ElectronicBoard.Registrar.Registrars;

public static class AppServicesRegistrar
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IAdvtService, AdvtService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IAdvtReviewService, AdvtReviewService>();
        services.AddScoped<IUserReviewService, UserReviewService>();
        services.AddScoped<IAdvtReportService, AdvtReportService>();
        services.AddScoped<IUserReportService, UserReportService>();
        services.AddScoped<ICategoryReportService, CategoryReportService>();
        services.AddScoped<IAccountService, AccountService>();
        
        return services;
    }
}