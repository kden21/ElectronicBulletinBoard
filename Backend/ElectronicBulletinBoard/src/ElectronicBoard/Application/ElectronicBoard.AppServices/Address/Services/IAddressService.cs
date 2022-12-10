namespace ElectronicBoard.AppServices.Address.Services;

public interface IAddressService
{
    public Task<string> GetSuggestions(string? cityName, CancellationToken cancellation);
    public Task<string> GetAddressById(string? cityFiasId, CancellationToken cancellation);
}