using ElectronicBoard.Contracts.Account.Dto;
using ElectronicBoard.Contracts.EmailSendler;

namespace ElectronicBoard.AppServices.EmailSendler;

public interface IEmailService
{
    public  Task<int> EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation);
    public  Task<int> PasswordRecoverySendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation);
    public Task EmailFeedBack(EmailFeedBackRequest request, CancellationToken cancellationToken);
}