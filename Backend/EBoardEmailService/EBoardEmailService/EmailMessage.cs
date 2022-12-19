namespace ElectronicBoard.Contracts.Shared.Models;

public class EmailMessage
{
    public string Subject { get; set; }
    public string Text { get; set; }
    public string ReceiverMail { get; set; }
    public string ReceiverName { get; set; }
}