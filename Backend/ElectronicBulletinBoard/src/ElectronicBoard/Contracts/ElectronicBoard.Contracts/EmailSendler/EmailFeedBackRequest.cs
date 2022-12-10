namespace ElectronicBoard.Contracts.EmailSendler;

public class EmailFeedBackRequest
{
    public int UserId { get; set; }
    public string Text { get; set; } 
    public string UserEmail { get; set; }
    public string UserName { get; set; }
}