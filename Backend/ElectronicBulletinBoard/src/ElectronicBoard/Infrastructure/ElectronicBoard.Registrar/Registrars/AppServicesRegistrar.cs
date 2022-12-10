using ElectronicBoard.AppServices.Account.Services;
using ElectronicBoard.AppServices.Address.Services;
using ElectronicBoard.AppServices.Advt.Services;
using ElectronicBoard.AppServices.Category.Services;
using ElectronicBoard.AppServices.Chat.Conversation.Services;
using ElectronicBoard.AppServices.Chat.ConversationMember.Services;
using ElectronicBoard.AppServices.Chat.Message.Services;
using ElectronicBoard.AppServices.Chat.Services;
using ElectronicBoard.AppServices.EmailSendler;
using ElectronicBoard.AppServices.Photo.Services;
using ElectronicBoard.AppServices.Report.AdvtReport.Services;
using ElectronicBoard.AppServices.Report.CategoryReport.Services;
using ElectronicBoard.AppServices.Report.UserReport.Services;
using ElectronicBoard.AppServices.Review.AdvtReview.Services;
using ElectronicBoard.AppServices.Review.UserReview.Services;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.AppServices.User.Services;
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
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IConversationService, ConversationService>();
        services.AddScoped<IConversationMemberService, ConversationMemberService>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}