namespace ElectronicBoard.Infrastructure.Exceptions;

/// <summary>
/// Исключение: Сущность не была обновлена
/// </summary>
[Serializable]
public class NoAccessException: Exception
{
    public NoAccessException(string message)
        : base(message)
    {
    }
}