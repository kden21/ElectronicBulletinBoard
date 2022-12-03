using ElectronicBoard.Contracts.Account.Dto;

namespace ElectronicBoard.AppServices.EmailSendler;

public interface IEmailService
{
    public void EmailSendlerMessage(string receiverMail, string receiverName, CancellationToken cancellation);
    //public Task<AccountDto> LoginAccount(CancellationToken cancellation);
}