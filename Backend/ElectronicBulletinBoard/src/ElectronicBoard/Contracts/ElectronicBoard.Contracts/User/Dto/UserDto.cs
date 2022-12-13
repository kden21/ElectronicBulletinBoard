using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.User.Dto;

/// <summary>
/// Модель представления пользователя.
/// </summary>
public class UserDto
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public int Id { get; set; }
    
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
    public string? Birthday { get; set; }
    
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
    public string? Photo { get; set; }
    
    /// <summary>
    /// E-mail пользователя.
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Идентификатор аккаунта.
    /// </summary>
    public int AccountId { get; set; }
    
    /// <summary>
    /// Статус пользователя.
    /// </summary>
    public StatusUser StatusUser { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public string? CreateDate { get; set; }
}