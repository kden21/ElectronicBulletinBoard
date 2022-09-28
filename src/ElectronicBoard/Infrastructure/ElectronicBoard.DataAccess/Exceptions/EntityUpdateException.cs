namespace ElectronicBoard.DataAccess.Exceptions;

/// <summary>
/// Исключение: Сущность не была обновлена
/// </summary>
[Serializable]
public class EntityUpdateException : Exception
{
    public EntityUpdateException(string message)
        : base(message)
    {
    }
}