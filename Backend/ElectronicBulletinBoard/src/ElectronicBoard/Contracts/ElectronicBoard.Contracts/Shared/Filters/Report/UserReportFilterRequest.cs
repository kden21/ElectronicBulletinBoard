using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters.Report;

public class UserReportFilterRequest : SharedFilterRequest
{
    public StatusCheckReport? StatusCheck { get; set; }
}