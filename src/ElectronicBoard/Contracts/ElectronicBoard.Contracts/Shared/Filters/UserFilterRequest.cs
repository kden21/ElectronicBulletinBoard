using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters;

public class UserFilterRequest : SharedFilterRequest
{
    public StatusUser? StatusUser { get; set; }
    public int? AdvtFavoriteId { get; set; }
}