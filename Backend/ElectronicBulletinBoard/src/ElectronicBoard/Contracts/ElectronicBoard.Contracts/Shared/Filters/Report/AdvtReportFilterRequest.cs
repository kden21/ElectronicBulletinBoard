using ElectronicBoard.Contracts.Shared.Enums;

namespace ElectronicBoard.Contracts.Shared.Filters.Report;

public class AdvtReportFilterRequest : SharedFilterRequest
{
    public StatusCheckReport? StatusCheck { get; set; }
}