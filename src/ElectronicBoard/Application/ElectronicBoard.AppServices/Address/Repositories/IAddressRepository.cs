namespace ElectronicBoard.AppServices.Address.Repositories;

public interface IAddressRepository
{
    public Task GetSuggestions(string? cityName, int userId, string? location, CancellationToken cancellation);
}