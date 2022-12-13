namespace ElectronicBoard.AppServices.Address.Services;

/// <summary>
/// Сервис для работы с адресом.
/// </summary>
public interface IAddressService
{
    /// <summary>
    /// Получение списка адресов, по первому вхождению введеного названия города.
    /// </summary>
    /// <param name="cityName">Название города.</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<List<Contracts.DaData.Address>> GetSuggestions(string? cityName, CancellationToken cancellation);
    
    /// <summary>
    /// Получения адреса по ФИАС.
    /// </summary>
    /// <param name="cityFiasId">ФИАС города</param>
    /// <param name="cancellation">Маркер отмены.</param>
    /// <returns></returns>
    public Task<string> GetAddressById(string? cityFiasId, CancellationToken cancellation);
}