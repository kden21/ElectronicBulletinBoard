using ElectronicBoard.AppServices.Account.Repositories;
using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Category.Repositories;
using ElectronicBoard.AppServices.Chat.Conversation.Repositories;
using ElectronicBoard.AppServices.Chat.ConversationMember.Repositories;
using ElectronicBoard.AppServices.Chat.Message.Repositories;
using ElectronicBoard.AppServices.Photo.Repositories;
using ElectronicBoard.AppServices.Report.AdvtReport.Repositories;
using ElectronicBoard.AppServices.Report.CategoryReport.Repositories;
using ElectronicBoard.AppServices.Report.UserReport.Repositories;
using ElectronicBoard.AppServices.Review.AdvtReview.Repositories;
using ElectronicBoard.AppServices.Review.UserReview.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.DataAccess;
using ElectronicBoard.DataAccess.Interfaces;
using ElectronicBoard.DataAccess.Repositories;
using ElectronicBoard.DataAccess.Repositories.Chat;
using ElectronicBoard.DataAccess.Repositories.Report;
using ElectronicBoard.DataAccess.Repositories.Review;
using ElectronicBoard.DataAccess.Repositories.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ElectronicBoard.Registrar.Registrars;

public static class DataAccessRegistrar
{
    private static string _containerStringVariable = "DOTNET_RUNNING_IN_CONTAINER";
    private static string _connectionStringLocal = "ElectronicBoardDbLocal";
    private static string _connectionStringDocker = "ElectronicBoardDbDocker";
    private static bool _isContainer;

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration, IHostEnvironment environment )
    {
        bool.TryParse(Environment.GetEnvironmentVariable(_containerStringVariable), out _isContainer);
        var connectionString = configuration.GetConnectionString(_isContainer ? _connectionStringDocker : _connectionStringLocal);
        
        if (string.IsNullOrEmpty(connectionString))
            throw new InvalidOperationException(
                $"???? ?????????????? ???????????? ??????????????????????");
        
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
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IConversationRepository, ConversationRepository>();
        services.AddScoped<IConversationMemberRepository, ConversationMemberRepository>();
        
        return services;
    }
}