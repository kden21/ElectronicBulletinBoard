using ElectronicBoard.Contracts.Chat.ConversationMember;

namespace ElectronicBoard.Contracts.Chat.Conversation;

/// <summary>
/// Модель представления беседы чата.
/// </summary>
public class ConversationDto
{
    /// <summary>
    /// Идентификатор беседы.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Коллекция членов чата.
    /// </summary>
    public ICollection<ConversationMemberDto> ConversationMembers { get; set; }

}