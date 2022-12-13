namespace ElectronicBoard.Contracts.Chat.ConversationMember;

/// <summary>
/// Модель представления члена беседы.
/// </summary>
public class ConversationMemberDto
{
    /// <summary>
    /// Идентификатор члена беседы.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор члена чата.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Идентификатор чата.
    /// </summary>
    public int ConversationId { get; set; }
}