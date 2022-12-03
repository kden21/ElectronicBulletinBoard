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

    public async void EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation)
    {
        await _publishEndpoint.Publish(new EmailMessage()
        {
            ReceiverMail = receiverMail, //"ks230den@gmail.com", 
            ReceiverName = receiverName,//"Xsuha", 
            Subject = "Подтвердите e-mail для EBoard", 
            Text = $"<h3>Регистрация на EBoard</h3>" +
                   $"<p>{receiverName},<br>Вы получили это письмо, потому что прошли процесс регистрации на <br>EBoard</p>" +
                   "<p>Чтобы подтвердить адрес e-mail, перейдите по <a href=\"http://localhost:4200/\">ссылке</a></p>" +
                   "<p>Письмо отправлено площадкой электронных объявлений EBoard для подтверждения адресса электронной " +
                   "почты. Если Вы не указывали этот адрес, проигнорируйте письмо.</p>"
        }, cancellation);
    }
}