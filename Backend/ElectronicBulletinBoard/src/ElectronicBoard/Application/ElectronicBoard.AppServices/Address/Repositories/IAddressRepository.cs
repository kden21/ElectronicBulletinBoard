namespace ElectronicBoard.AppServices.Address.Repositories;

/// <summary>
/// Репозиторий для работы с адресом.
/// </summary>
public interface IAddressRepository
{
    //TODO:где используется этот класс?
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cityName"></param>
    /// <param name="userId"></param>
    /// <param name="location"></param>
    /// <param name="cancellation"></param>
    /// <returns></returns>
    public Task GetSuggestions(string? cityName, int userId, string? location, CancellationToken cancellation);
}