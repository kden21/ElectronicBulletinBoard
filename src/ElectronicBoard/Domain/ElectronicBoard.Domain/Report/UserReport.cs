namespace ElectronicBoard.Domain.Report;

public class UserReport : Report
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
}