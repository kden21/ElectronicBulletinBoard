namespace ElectronicBoard.Contracts.Chat.Message;

/// <summary>
/// Данные для коннекта пользователя к беседе.
/// </summary>
public class ChatConnectRequest
{
    /// <summary>
    /// Идентификатор беседы.
    /// </summary>
    public int ConversationId { get; set; }
}