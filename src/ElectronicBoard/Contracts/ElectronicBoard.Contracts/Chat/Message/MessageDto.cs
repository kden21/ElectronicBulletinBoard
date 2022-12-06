namespace ElectronicBoard.Contracts.Chat.Message;

public class MessageDto
{
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
    /// Автор сообщения.
    /// </summary>
    //public UserEntity User { get; set; }
    
    /// <summary>
    /// Идентификатор чата, в который отправлено сообщение.
    /// </summary>
    public int ConversationId { get; set; }
    
    public string CreateDate { get; set; }
    
    /// <summary>
    /// Чат, в который отправлено сообщение.
    /// </summary>
   // public ConversationEntity Conversation { get; set; }
}