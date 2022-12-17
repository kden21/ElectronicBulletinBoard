namespace ElectronicBoard.Infrastructure.Exceptions;

/// <summary>
/// Исключение: Аккаунт не существует.
/// </summary>
[Serializable]
public class AccountNoExistsException : Exception
{
    public AccountNoExistsException(string message)
        : base(message)
    {
    }
}