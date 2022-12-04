namespace ElectronicBoard.Infrastructure.Exceptions;

public class EmailNoConfirmException:Exception
{
    public EmailNoConfirmException(string message)
        : base(message)
    {
    }
}