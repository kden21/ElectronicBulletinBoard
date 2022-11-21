using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Domain.Report;
using ElectronicBoard.Domain.Review;
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
    public string? LastName { get; set; }
    
    /// <summary>
    /// Дата рождения пользователя.
    /// </summary>
    public DateTime? Birthday { get; set; }
    
    /// <summary>
    /// Телефонный номер пользователя.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public Role Role { get; set; }
    
    
    /// <summary>
    /// Фотография пользователя.
    /// </summary>
    public byte[]? Photo { get; set; }
    public string? Email { get; set; }
    
    public StatusUser StatusUser { get; set; }
    
    /// <summary>
    /// Коллекция объявлений пользователя.
    /// </summary>
    public ICollection<AdvtEntity>? Advts { get; set; }
    
    /// <summary>
    /// Коллекция отзывов о пользователе.
    /// </summary>
    public ICollection<UserReviewEntity>? UserReviews { get; set; }
    
    /// <summary>
    /// Коллекция отзывов пользователя на пользователей.
    /// </summary>
    public ICollection<UserReviewEntity>? AuthorUserReviews { get; set; }
    
    /// <summary>
    /// Коллекция отзывов пользователя на объявления.
    /// </summary>
    public ICollection<AdvtReviewEntity>? AuthorAdvtReviews { get; set; }
    
    /// <summary>
    /// Коллекция жалоб на пользователя.
    /// </summary>
    public ICollection<UserReportEntity>? UserReports { get; set; }
    
    /// <summary>
    /// Коллекция жалоб пользователя на пользователей.
    /// </summary>
    public ICollection<UserReportEntity>? AuthorUserReports { get; set; }
    
    /// <summary>
    /// Коллекция жалоб польхователя на объявления.
    /// </summary>
    public ICollection<AdvtReportEntity>? AuthorAdvtReports { get; set; }
    
    public int AccountId { get; set; }
    
    public AccountEntity? Account { get; set; }
}