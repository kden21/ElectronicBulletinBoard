using AutoMapper;
using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Services.Advt;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Advt.Services;

/// <inheritdoc />
public class AdvtService : IAdvtService
{
    private readonly IAdvtRepository _advtRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public AdvtService(IAdvtRepository advtRepository, IUserRepository userRepository, IMapper mapper)
    {
        _advtRepository = advtRepository;
        _userRepository = userRepository;
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

    public async Task<IEnumerable<AdvtDto>> GetAllAdvts(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(await _advtRepository.GetAllAdvtEntities(cancellation));
    }
    
    public async Task<IEnumerable<AdvtDto>> GetFilterAdvts(AdvtFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(await _advtRepository.GetFilterAdvtEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteAdvt(int advtId, CancellationToken cancellation)
    {
        await _advtRepository.DeleteAdvtEntity(advtId, cancellation);
    }
    
    /// <inheritdoc />
    public async Task SoftDeleteAdvt(int advtId, CancellationToken cancellation)
    {
        await _advtRepository.SoftDeleteAdvtEntity(advtId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateAdvt(int advtId, AdvtDto advtDto, CancellationToken cancellation)
    {
        advtDto.Id = advtId;
        var advt = _mapper.Map<AdvtEntity>(advtDto);
        await _advtRepository.UpdateAdvtEntity(advt, cancellation);
    }
    
    /// <inheritdoc />
    public async Task AddAdvtInFavorite(int advtId, int userId, CancellationToken cancellation)
    {
        /*advtDto.Id = advtId;
        var advt = _mapper.Map<AdvtEntity>(advtDto);*/
        var advtEntity = await _advtRepository.GetAdvtEntityById(advtId, cancellation);
        var userEntity = await _userRepository.GetUserEntityById(userId, cancellation);
        List<UserEntity> userVoters=new List<UserEntity>();
        userVoters.Add(userEntity);
        advtEntity.UsersVoters=userVoters;
        await _advtRepository.UpdateAdvtEntity(advtEntity, cancellation);
    }
}