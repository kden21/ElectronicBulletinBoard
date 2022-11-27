using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.User.Dto;

namespace ElectronicBoard.Contracts.Advt.Dto;

/// <summary>
/// Модель представления объявления.
/// </summary>
public class AdvtDto
{
    /// <summary>
    /// Идентификатор.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name { get; set; } 
    
    /// <summary>
    /// Стоимость.
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; }
    
    /// <summary>
    /// Фото профиля.
    /// </summary>
    public ICollection<string>? Photos { get; set; }
    
    /// <summary>
    /// Статус актуальности объявления.
    /// </summary>
    public StatusAdvt Status { get; set; }
    public string Location { get; set; }
    
    /// <summary>
    /// Идентификатор категории объявления.
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя-владельца объявления.
    /// </summary>
    public int? AuthorId { get; set; }
   // public ICollection<UserDto> UserChooseAdvt { get; set; }
    
    public string? CreateDate { get; set; }
}