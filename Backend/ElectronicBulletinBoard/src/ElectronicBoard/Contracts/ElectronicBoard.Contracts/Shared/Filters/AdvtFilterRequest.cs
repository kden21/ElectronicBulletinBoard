using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Параметр фильтрации объявлений.
/// </summary>
public class AdvtFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Название объявления.
    /// </summary>
    public string? Name {get; set;}
    
    /// <summary>
    /// Адрес объявления.
    /// </summary>
    public string? Location {get; set;}
    
    /// <summary>
    /// Описание объявления.
    /// </summary>
    public string? Description {get; set;}
    
    /// <summary>
    /// Идентиыикатор категории объявлений.
    /// </summary>
    public int? CategoryId { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя - владельца объявления.
    /// </summary>
    public int? UserId { get; set; }
    
    /// <summary>
    /// Статус объявления.
    /// </summary>
    public StatusAdvt Status { get; set; }
    
    /// <summary>
    /// Идентификатор последнего объявления в списке.
    /// </summary>
    public int? LastAdvtId { get; set; }
    
    /// <summary>
    /// Наличие фото у объявления.
    /// </summary>
    public bool Photo { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя - избирателя объявления.
    /// </summary>
    public int? UserVoter { get; set; }
}