namespace ElectronicBoard.Infrastructure.Exceptions;

/// <summary>
/// Исключение: Сущность не была найдена.
/// </summary>
[Serializable]
public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message)
        : base(message)
    {
    }
}