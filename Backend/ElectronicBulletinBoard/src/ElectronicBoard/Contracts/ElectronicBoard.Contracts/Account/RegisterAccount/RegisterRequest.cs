using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Account.RegisterAccount;

public class RegisterRequest
{
    /// <summary>
    /// Логин.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль.
    /// </summary>
    public string Password{ get; set; }
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Отчество пользователя.
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Дата рождения пользователя.
    /// </summary>
    public string? Birthday { get; set; }
    
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public Role Role { get; set; }
    
    /// <summary>
    /// Электронный адрес пользователя.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Идентификатор аккаунта пользователя.
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Статус пользователя.
    /// </summary>
    public StatusUser StatusUser { get; set; }
    
    /// <summary>
    /// Номер телефона пользователя.
    /// </summary>
    public string? PhoneNumber { get; set; }
}