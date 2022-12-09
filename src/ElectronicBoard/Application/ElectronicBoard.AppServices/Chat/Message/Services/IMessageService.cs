using ElectronicBoard.Contracts.Chat.Message;

namespace ElectronicBoard.AppServices.Chat.Message.Services;

public interface IMessageService
{
    public Task<MessageDto> CreateMessage(MessageDto model, CancellationToken cancellationToken);
    public Task<IEnumerable<MessageDto>> GetFilterMessages(int conversationId, CancellationToken cancellation);
}