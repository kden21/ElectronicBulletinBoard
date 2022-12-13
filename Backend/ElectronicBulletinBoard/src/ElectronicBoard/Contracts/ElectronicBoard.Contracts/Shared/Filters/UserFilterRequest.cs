using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters;

/// <summary>
/// Параметры фильтрации пользователей.
/// </summary>
public class UserFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Статус пользователя.
    /// </summary>
    public StatusUser? StatusUser { get; set; }
    
    /// <summary>
    /// Идентификатор избранного объявления.
    /// </summary>
    public int? AdvtFavoriteId { get; set; }
}