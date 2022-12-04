using ElectronicBoard.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.Domain;

[Index(nameof(Login), Name = "IX_Login", IsUnique=true)]
public class AccountEntity : Entity
{
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    public string? UserCode { get; set; }
    public UserEntity? User { get; set; }
    
    
}