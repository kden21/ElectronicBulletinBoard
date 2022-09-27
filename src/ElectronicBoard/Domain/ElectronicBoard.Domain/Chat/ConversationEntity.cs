using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Chat;

/// <summary>
/// Чат.
/// </summary>
public class ConversationEntity : Entity
{
    /// <summary>
    /// Коллекция членов чата.
    /// </summary>
    public ICollection<ConversationMemberEntity> ConversationMembers { get; set; }
    
    /// <summary>
    /// Коллекция сообщений.
    /// </summary>
    public ICollection<MessageEntity> Messages { get; set; }
}