namespace ElectronicBoard.Contracts.Shared.Models;

/// <summary>
/// Модель сообщения для EmailService.
/// </summary>
public class EmailMessage
{
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
    public string ReceiverMail { get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string ReceiverName { get; set; }
}