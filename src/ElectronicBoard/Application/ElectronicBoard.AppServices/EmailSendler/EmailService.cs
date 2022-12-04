using ElectronicBoard.Contracts.Shared.Models;
using MassTransit;

namespace ElectronicBoard.AppServices.EmailSendler;

public class EmailService:IEmailService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EmailService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task<int> EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        Random rnd = new Random();
        int code = rnd.Next(1000,10000);
        await _publishEndpoint.Publish(new EmailMessage()
        {
            ReceiverMail = receiverMail, //"ks230den@gmail.com", 
            ReceiverName = receiverName,//"Xsuha", 
            Subject = "Подтвердите e-mail для EBoard", 
            Text = "<h3>Регистрация на EBoard</h3>" +
                   $"<p>{receiverName},<br>Вы получили это письмо, потому что прошли процесс регистрации на <b>EBoard</b></p>" +
                   $"<p>Ваш код для подтверждения e-mail адреса: <b>{code}</b> </p>" +
                   "<p>Письмо отправлено площадкой электронных объявлений EBoard для подтверждения адреса электронной " +
                   "почты. Если Вы не указывали этот адрес, проигнорируйте письмо.</p>"
            //TODO://перейдите по <a href=\"http://localhost:4200/\">ссылке</a>
        }, cancellation);

        return code;
    }

    public async Task<int> PasswordRecoverySendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        Random rnd = new Random();
        int code = rnd.Next(1000,10000);
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