using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Message.Services;

public interface IMessageService
{
    
    public Task<IEnumerable<MessageDto>> GetFilterMessages( CancellationToken cancellation);
}