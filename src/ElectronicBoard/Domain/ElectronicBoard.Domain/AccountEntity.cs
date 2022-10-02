using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

public class AccountEntity : Entity
{
    /// <summary>
    /// Электронный адрес пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    public UserEntity? User { get; set; }
}