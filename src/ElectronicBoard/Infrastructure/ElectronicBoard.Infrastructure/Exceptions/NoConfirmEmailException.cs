namespace ElectronicBoard.Infrastructure.Exceptions;

public class NoConfirmEmailException:Exception
{
    public NoConfirmEmailException(string message)
        : base(message)
    {
    }
}