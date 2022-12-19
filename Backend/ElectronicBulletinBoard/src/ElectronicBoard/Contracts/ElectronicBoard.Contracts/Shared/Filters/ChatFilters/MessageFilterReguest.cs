namespace ElectronicBoard.Contracts.Shared.Filters.ChatFilters;

public class MessageFilterReguest: SharedFilterRequest
{
    public int? UserId { get; set; }
    public int? ConversationId { get; set; }
}