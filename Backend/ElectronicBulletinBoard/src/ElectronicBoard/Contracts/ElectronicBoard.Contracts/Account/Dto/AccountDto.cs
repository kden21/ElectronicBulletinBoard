namespace ElectronicBoard.Contracts.Account.Dto;

/// <summary>
/// Модель представления аккаунта.
/// </summary>
public class AccountDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Код для подтверждения почты.
    /// </summary>
    public string UserCode { get; set; }
}