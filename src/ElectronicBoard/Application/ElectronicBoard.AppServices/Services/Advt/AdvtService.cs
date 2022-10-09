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
    public async Task<AdvtDto> GetAdvtById(int advtId, CancellationToken cancellation)
    {
        var advtEntity = await _advtRepository.GetAdvtEntityById(advtId, cancellation);
        return _mapper.Map<AdvtDto>(advtEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtDto> CreateAdvt(AdvtDto advtDto, CancellationToken cancellation)
    {
        var advtEntity = _mapper.Map<AdvtEntity>(advtDto);
        var id = await _advtRepository.AddAdvtEntity(advtEntity, cancellation);
        advtDto.Id = id;
        return advtDto;
    }

    public async Task<IEnumerable<AdvtDto>> GetAllAdvts(AdvtFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(await _advtRepository.GetAllAdvtEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteAdvt(int advtId, CancellationToken cancellation)
    {
        await _advtRepository.DeleteAdvtEntity(advtId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateAdvt(int advtId, AdvtDto advtDto, CancellationToken cancellation)
    {
        advtDto.Id = advtId;
        var advt = _mapper.Map<AdvtEntity>(advtDto);
        await _advtRepository.UpdateAdvtEntity(advt, cancellation);
    }
}