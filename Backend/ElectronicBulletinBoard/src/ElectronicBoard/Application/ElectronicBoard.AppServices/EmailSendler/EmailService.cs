using ElectronicBoard.AppServices.Shared.Helpers.CodeGeneratorHelper;
using ElectronicBoard.AppServices.User.Services;
using ElectronicBoard.Contracts.EmailSendler;
using ElectronicBoard.Contracts.Shared.Models;
using MassTransit;

namespace ElectronicBoard.AppServices.EmailSendler;

/// <inheritdoc />
public class EmailService:IEmailService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EmailService(IPublishEndpoint publishEndpoint, IUserService userService)
    {
        _publishEndpoint = publishEndpoint;
    }
    
    /// <inheritdoc />
    public async Task EmailFeedBack(EmailFeedBackRequest request, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish(new EmailMessage()
        {
            ReceiverMail = "electronic.board@inbox.ru",
            ReceiverName = "Техподдержка EBoard",
            Subject = request.Subject, 
            //todo:изменить ссылку на пользователя
            Text = $"<h3>Сообщения от пользователя <a href=\"http://electronicboard.ru/users/{request.UserId}\">{request.UserName}</a></h3>" +
                   $"<p>{request.Text}</p>" +
                   $"<p>Адрес для обратной связи: {request.UserEmail}</p>" 
        }, cancellationToken);
    }
    
    /// <inheritdoc />
    public async Task<int> EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        int code = CodeGeneratorHelper.GetMailVerificationCode();
        
        await _publishEndpoint.Publish(new EmailMessage()
        {
            ReceiverMail = receiverMail, 
            ReceiverName = receiverName,
            Subject = "Подтвердите e-mail для EBoard", 
            Text = "<h3>Регистрация на EBoard</h3>" +
                   $"<p>{receiverName},<br>Вы получили это письмо, потому что прошли процесс регистрации на <b>EBoard</b></p>" +
                   $"<p>Ваш код для подтверждения e-mail адреса: <b>{code}</b> </p>" +
                   "<p>Письмо отправлено площадкой электронных объявлений EBoard для подтверждения адреса электронной " +
                   "почты. Если Вы не указывали этот адрес, проигнорируйте письмо.</p>"
        }, cancellation);

        return code;
    }

    /// <inheritdoc />
    public async Task<int> PasswordRecoverySendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        int code = CodeGeneratorHelper.GetMailVerificationCode();
        
        await _publishEndpoint.Publish(new EmailMessage()
        {
            ReceiverMail = receiverMail, 
            ReceiverName = receiverName,
            Subject = "Подтвердите e-mail для доступа к аккаунту на EBoard", 
            Text = $"<p>{receiverName},<br>Вы получили это письмо, потому что была совершена попытка сброса пароля Вашего аккаунта на <b>EBoard</b></p>" +
                   $"<p>Ваш код для смены пароля: <b>{code}</b> </p>" +
                   "<p>Письмо отправлено площадкой электронных объявлений EBoard для подтверждения адреса электронной " +
                   "почты. Если Вы не указывали этот адрес, проигнорируйте письмо.</p>"
        }, cancellation);

        return code;
    }
}