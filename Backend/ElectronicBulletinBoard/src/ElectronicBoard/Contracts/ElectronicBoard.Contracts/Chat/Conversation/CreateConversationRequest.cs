namespace ElectronicBoard.Contracts.Chat.Conversation;

/// <summary>
/// Данные для создания беседы.
/// </summary>
public class CreateConversationRequest
{
    /// <summary>
    /// Список идентификаторов членов чата.
    /// </summary>
    public int[] UsersId { get; set; }
}