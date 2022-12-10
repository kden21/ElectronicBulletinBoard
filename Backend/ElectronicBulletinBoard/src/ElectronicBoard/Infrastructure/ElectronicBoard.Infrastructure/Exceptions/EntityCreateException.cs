namespace ElectronicBoard.Infrastructure.Exceptions;

/// <summary>
/// Исключение: Сущность не была добавлена в БД.
/// </summary>
[Serializable]
public class EntityCreateException : Exception
{
    public EntityCreateException(string message)
        : base(message)
    {
    }
}