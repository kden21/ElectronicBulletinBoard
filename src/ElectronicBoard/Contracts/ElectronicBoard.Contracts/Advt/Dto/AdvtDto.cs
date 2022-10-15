using ElectronicBoard.Contracts.Shared.Enums;

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
    public string? Photo { get; set; }
    
    /// <summary>
    /// Статус актуальности объявления.
    /// </summary>
    public StatusAdvt Status { get; set; }
    
    /// <summary>
    /// Идентификатор категории объявления.
    /// </summary>
    public int CategoryId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя-владельца объявления.
    /// </summary>
    public int UserId { get; set; }
}