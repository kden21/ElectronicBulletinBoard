namespace ElectronicBoard.Infrastructure.Exceptions;

[Serializable]
public class AccountNoExistsException : Exception
{
    public AccountNoExistsException(string message)
        : base(message)
    {
    }
}