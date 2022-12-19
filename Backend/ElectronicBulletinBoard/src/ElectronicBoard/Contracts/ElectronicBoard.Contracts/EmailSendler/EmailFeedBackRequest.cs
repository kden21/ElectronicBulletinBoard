namespace ElectronicBoard.Contracts.EmailSendler;

/// <summary>
/// Данные для отправки письма в техподдержку.
/// </summary>
public class EmailFeedBackRequest
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int UserId { get; set; }
    
    /// <summary>
    /// Заголовок письма.
    /// </summary>
    public string Subject { get; set; }
    
    /// <summary>
    /// Содержимое письма.
    /// </summary>
    public string Text { get; set; } 
    
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string UserEmail { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string UserName { get; set; }
}