namespace ElectronicBoard.Infrastructure.Exceptions;

/// <summary>
/// Исключение: Неверный код подтверждения e-mail.
/// </summary>
public class NoConfirmEmailException:Exception
{
    public NoConfirmEmailException(string message)
        : base(message)
    {
    }
}