namespace ElectronicBoard.Contracts.EmailSendler;

/// <summary>
/// Данные для отправки письма со сбросом пароля.
/// </summary>
public class EmailConfirmRequest
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Код подтверждения.
    /// </summary>
    public string UserCode {get; set; }
}