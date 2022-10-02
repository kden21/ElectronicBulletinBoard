using ElectronicBoard.Contracts.Enums;

namespace ElectronicBoard.Contracts.Dto;

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
    public string LastName { get; set; }
    
    /// <summary>
    /// Дата рождения пользователя.
    /// </summary>
    public DateTime Birthday { get; set; }
    
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
    
    public int AccountId { get; set; }
}