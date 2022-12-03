namespace ElectronicBoard.Contracts.EmailSendler;

public class EmailConfirmRequest
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string UserCode {get; set; }
}