namespace ElectronicBoard.Contracts.Chat.Message;

/// <summary>
/// Модель представления сообщения.
/// </summary>
public class MessageDto
{
    /// <summary>
    /// Идентификатор сообщения.
    /// </summary>
    public int? Id { get; set; }
    
    /// <summary>
    /// Содержание сообщения.
    /// </summary>
    public string Description { get; set; }
    
    /// <summary>
    /// Идентификатор автора сообщения.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Идентификатор чата, в который отправлено сообщение.
    /// </summary>
    public int ConversationId { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public string CreateDate { get; set; }
}