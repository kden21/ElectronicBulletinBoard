using ElectronicBoard.Contracts.Shared.Models;
using MailKit.Net.Smtp;
using MassTransit;
using MimeKit;

public class EmailConsumer: IConsumer<EmailMessage>
{
    private readonly string email;
    private readonly string password;

    public EmailConsumer(IConfiguration configuration)
    {
        this.email = configuration.GetSection("EmailData").GetSection("EmailAddress").Value;
        this.password = configuration.GetSection("EmailData").GetSection("Password").Value;
    }
    
    public async Task Consume(ConsumeContext<EmailMessage> context)
    {
        var message = context.Message;
        
        try
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("ElectronicBoard", email));
            emailMessage.To.Add(new MailboxAddress(message.ReceiverName, message.ReceiverMail));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message.Text
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.mail.ru", 465, true);
            await client.AuthenticateAsync(email, password);
            await client.SendAsync(emailMessage);

            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            throw new Exception($"Ошибка отправки сообщения на Email {e.Message}");
        }
    }
}