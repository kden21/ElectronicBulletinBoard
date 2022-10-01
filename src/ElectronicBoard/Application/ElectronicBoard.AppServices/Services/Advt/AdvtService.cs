using AutoMapper;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Services.Advt;

/// <inheritdoc />
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
    public async Task<AdvtDto> GetAdvtById(int advtId)
    {
        var advtEntity = await _advtRepository.GetAdvtEntityById(advtId);
        return _mapper.Map<AdvtDto>(advtEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtDto> CreateAdvt(AdvtDto advtDto)
    {
        var advtEntity = _mapper.Map<AdvtEntity>(advtDto);
        var id = await _advtRepository.AddAdvtEntity(advtEntity);
        advtDto.Id = id;
        return advtDto;
    }

    public IEnumerable<AdvtDto> GetAllAdvts(AdvtFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(_advtRepository.GetAllAdvtEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteAdvt(int advtId)
    {
        await _advtRepository.DeleteAdvtEntity(advtId);
    }

    /// <inheritdoc />
    public async Task UpdateAdvt(int advtId, AdvtDto advtDto)
    {
        advtDto.Id = advtId;
        var advt = _mapper.Map<AdvtEntity>(advtDto);
        await _advtRepository.UpdateAdvtEntity(advt);
    }
}