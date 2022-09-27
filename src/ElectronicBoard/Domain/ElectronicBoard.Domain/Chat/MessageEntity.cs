using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain.Chat;

/// <summary>
/// Сообщение.
/// </summary>
public class MessageEntity : Entity
{
    /// <summary>
    /// Содержание сообщения.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Дата создания сообщения.
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Идентификатор автора сообщения.
    /// </summary>
    public int AuthorId { get; set; }
    
    /// <summary>
    /// Автор сообщения.
    /// </summary>
    public UserEntity Author { get; set; }
    
    /// <summary>
    /// Идентификатор чата, в который отправлено сообщение.
    /// </summary>
    public int ConversationId { get; set; }
    
    /// <summary>
    /// Чат, в который отправлено сообщение.
    /// </summary>
    public ConversationEntity Conversation { get; set; }
}