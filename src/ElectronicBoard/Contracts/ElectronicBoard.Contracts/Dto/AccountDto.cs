namespace ElectronicBoard.Contracts.Dto;

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
    /// Электронный адрес пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
}