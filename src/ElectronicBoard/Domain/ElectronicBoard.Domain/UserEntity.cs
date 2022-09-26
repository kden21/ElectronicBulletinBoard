using ElectronicBoard.Contracts.Enums;
using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Shared;

namespace ElectronicBoard.Domain;

/// <summary>
/// Пользователь.
/// </summary>
public class UserEntity : Entity
{
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Отчество пользователя.
    /// </summary>
    public string? MiddleName { get; set; }
    
    /// <summary>
    /// Фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Дата рождения пользователя.
    /// </summary>
    public DateTime Birthday { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Photo { get; set; }
    //
    public ICollection<AdvtEntity> Advts { get; set; }
    //public ICollection<UserReview> UserReviews { get; set; }
    //public ICollection<UserReport> UserReports { get; set; }
}