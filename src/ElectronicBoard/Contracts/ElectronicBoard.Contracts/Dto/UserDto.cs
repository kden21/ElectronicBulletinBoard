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
    /// Фамилия пользователя.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Телефонный номер пользователя.
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Электронный адрес пользователя.
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Фотография пользователя.
    /// </summary>
    public string? Photo { get; set; }
    
   
}