using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Dto.Filters;

namespace ElectronicBoard.AppServices.Advt.Services;

public class AdvtService : IAdvtService
{
    private readonly IAdvtRepository _advtRepository;
    
    public AdvtService(IAdvtRepository advtRepository)
    {
        _advtRepository = advtRepository;
    }
    public async Task<AdvtDto> GetById(int id)
    {
        var advtEntity = await _advtRepository.GetByIdAsync(id);
        return new AdvtDto
        {
            Id = advtEntity.Id,
            Description = advtEntity.Description,
            Name = advtEntity.Name,
            Price = advtEntity.Price
        };
    }

    public async Task CreateAdvt(AdvtDto advtDto)
    {
        
    }
    /*public Task<IReadOnlyCollection<AdvtDto>> GetAll(int take, int skip)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<AdvtDto>> GetAllFiltered(AdvtFilterRequest filterRequest)
    {
        throw new NotImplementedException();
    }*/
}