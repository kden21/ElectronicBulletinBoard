using ElectronicBoard.AppServices.Address.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Domain;

namespace ElectronicBoard.DataAccess.Repositories;

public class AddressRepository:IAddressRepository
{
    private readonly IRepository<AdvtEntity> _repository;

    public AddressRepository(IRepository<AdvtEntity> repository)
    {
        _repository = repository;
    }
    public async Task GetSuggestions(string? cityName, int userId, string? location, CancellationToken cancellation)
    { 
        var userEntity = await _repository.GetEntityById(userId, cancellation);
        userEntity.Location = location;
        await _repository.UpdateEntity(userEntity, cancellation);
    }
}