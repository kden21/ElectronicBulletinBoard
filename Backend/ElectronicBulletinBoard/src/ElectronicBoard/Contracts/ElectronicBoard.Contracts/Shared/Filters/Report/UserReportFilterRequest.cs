using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters.Report;

/// <summary>
/// Параметр фильтрации жалоб на пользователей.
/// </summary>
public class UserReportFilterRequest : SharedFilterRequest
{
    /// <summary>
    /// Статус проверки жалобы.
    /// </summary>
    public StatusCheckReport? StatusCheck { get; set; }
}