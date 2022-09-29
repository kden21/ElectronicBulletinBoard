using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Dto.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Services.Advt;

public class AdvtService : IAdvtService
{
    private readonly IAdvtRepository _advtRepository;
    private readonly IMapper _mapper;
    
    public AdvtService(IAdvtRepository advtRepository, IMapper mapper)
    {
        _advtRepository = advtRepository;
        _mapper = mapper;
    }
    
    /// <inheritdoc />
    public async Task<AdvtDto> GetAdvtById(int id)
    {
        var advtEntity = await _advtRepository.GetByIdAsync(id);
        return _mapper.Map<AdvtDto>(advtEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtDto> CreateAdvt(AdvtDto advtDto)
    {
        var advtEntity = _mapper.Map<AdvtEntity>(advtDto);
        var id = await _advtRepository.AddAsync(advtEntity);
        advtDto.Id = id;
        return advtDto;
    }

    /// <inheritdoc />
    public IEnumerable<AdvtDto> GetAll()
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(_advtRepository.GetAll());
    }

    public IEnumerable<AdvtDto> GetAllFiltered(AdvtFilterRequest filterRequest)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(_advtRepository.GetAllFiltered(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteAdvt(int id)
    {
        await _advtRepository.DeleteAsync(id);
    }

    /// <inheritdoc />
    public async Task UpdateAdvt(int id, AdvtDto advtDto)
    {
        advtDto.Id = id;
        var advt = _mapper.Map<AdvtEntity>(advtDto);
        await _advtRepository.UpdateAsync(advt);
    }
}