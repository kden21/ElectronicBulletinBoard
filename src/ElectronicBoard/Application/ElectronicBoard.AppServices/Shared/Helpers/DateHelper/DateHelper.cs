using System.Text;

namespace ElectronicBoard.AppServices.Shared.Helpers.DateHelper;


public static class DateHelper
{
    public static DateTime? ToDateTime(string? dateStr)
    {
        var sb = new StringBuilder(dateStr);
        sb.Insert(2, '.').Insert(5,'.');

        if (dateStr != null)
            return DateTime.Parse(sb.ToString()).SetKindUtc();
        else
            return null;
    }
    public static DateTime? SetKindUtc(this DateTime dateTime)
    {
        if (dateTime.Kind == DateTimeKind.Utc) { return dateTime; }
        return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
    }
}