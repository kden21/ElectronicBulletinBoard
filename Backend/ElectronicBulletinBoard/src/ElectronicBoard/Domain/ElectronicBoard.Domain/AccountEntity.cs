using System.ComponentModel.DataAnnotations;
using ElectronicBoard.Domain.Shared;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.Domain;

[Index(nameof(Login), Name = "IX_Login", IsUnique=true)]
public class AccountEntity : Entity
{
    /// <summary>
    /// Логин пользователя.
    /// </summary>
    [Required]
    [StringLength(64)]
    public string Login { get; set; }
    
    /// <summary>
    /// Пароль пользователя.
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Код для подтверждения почты.
    /// </summary>
    public string? UserCode { get; set; }
    
    /// <summary>
    /// Пользователь, которому принадлежит аккаунт.
    /// </summary>
    public UserEntity? User { get; set; }

}