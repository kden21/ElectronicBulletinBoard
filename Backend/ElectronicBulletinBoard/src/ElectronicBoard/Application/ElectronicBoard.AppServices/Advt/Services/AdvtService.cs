using AutoMapper;
using ElectronicBoard.AppServices.Address.Services;
using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Photo.Services;
using ElectronicBoard.AppServices.User.Repositories;
using ElectronicBoard.Contracts.Advt.Dto;
using ElectronicBoard.Contracts.Advt.UpdateAdvt;
using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using ElectronicBoard.Infrastructure.Exceptions;

namespace ElectronicBoard.AppServices.Advt.Services;

/// <inheritdoc />
public class AdvtService : IAdvtService
{
    private readonly IAdvtRepository _advtRepository;
    private readonly IUserRepository _userRepository;
    private readonly IPhotoService _photoService;
    private readonly IAddressService _addressService;
    private readonly IMapper _mapper;
    
    public AdvtService(IAdvtRepository advtRepository, IUserRepository userRepository, IMapper mapper, IPhotoService photoService, IAddressService addressService)
    {
        _advtRepository = advtRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _photoService = photoService;
        _addressService = addressService;
    }
    
    /// <inheritdoc />
    public async Task<AdvtDto> GetAdvtById(int advtId, CancellationToken cancellation)
    {
        var advtEntity = await _advtRepository.GetAdvtEntityById(advtId, cancellation);
        advtEntity.Location = await _addressService.GetAddressById(advtEntity.Location, cancellation);
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
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtDto>> GetAllAdvts(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(await _advtRepository.GetAllAdvtEntities(cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtDto>> GetFilterAdvts(AdvtFilterRequest? filterRequest, CancellationToken cancellation)
    {
        var locations = await _addressService.GetSuggestions(filterRequest.Location, cancellation);
        if (locations.Count != 0)
            filterRequest.Location=locations[0].CityFias;
        
        IEnumerable<AdvtDto> advts = _mapper.Map<IEnumerable<AdvtEntity>, IEnumerable<AdvtDto>>(await _advtRepository.GetFilterAdvtEntities(filterRequest, cancellation));
       
        foreach (var advt in advts)
        {
            advt.Location = _addressService.GetAddressById(advt.Location, cancellation).Result;
        }

        return advts;
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
    public async Task UpdateAdvt(int advtId, UpdateAdvtRequest model, CancellationToken cancellation)
    {
        foreach (var photo in model.Photos)
        {
            await _photoService.CreatePhoto(new PhotoDto()
            {
                Base64Str = photo,
                AdvtId = advtId
            }, cancellation);
        }

        foreach (var photoId in model.DeletePhotoIds)
        {
            await _photoService.DeletePhoto(photoId, cancellation);
        }
        
        model.Advt.Id = advtId;
        var advt = _mapper.Map<AdvtEntity>(model.Advt);
        await _advtRepository.UpdateAdvtEntity(advt, cancellation);
    }
    
    /// <inheritdoc />
    public async Task AdvtInFavorite(int advtId, int userId, StatusAction status, CancellationToken cancellation)
    {
        var advtEntity = await _advtRepository.GetAdvtEntityByIdIncludeUserVoters(advtId, cancellation);
        var userEntity = await _userRepository.GetUserEntityById(userId, cancellation);
        
        if (status==StatusAction.Add)
        {
            try
            {
                advtEntity.UsersVoters.Add(userEntity!);
            }
            catch
            {
                throw new EntityNotFoundException("Не удалось добавить объявление в список избранных");
            }
        }
        else if(status==StatusAction.Delete)
        {
            try
            {
                advtEntity.UsersVoters.Remove(userEntity!);
            }
            catch
            {
                throw new EntityNotFoundException("Не удалось удалить объявление из списка избранных");
            }
        }
        
        await _advtRepository.UpdateAdvtEntity(advtEntity, cancellation);
    }
}