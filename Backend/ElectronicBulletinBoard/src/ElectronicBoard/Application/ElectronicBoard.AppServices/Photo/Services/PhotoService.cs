using AutoMapper;
using ElectronicBoard.AppServices.Photo.Repositories;
using ElectronicBoard.Contracts.Photo;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;

namespace ElectronicBoard.AppServices.Photo.Services;

/// <inheritdoc />
public class PhotoService:IPhotoService
{
    private readonly IPhotoRepository _photoRepository;
    private readonly IMapper _mapper;
    
    public PhotoService(IPhotoRepository photoRepository, IMapper mapper)
    {
        _photoRepository = photoRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<PhotoDto> GetPhotoById(int photoId, CancellationToken cancellation)
    {
        var photoEntity = await _photoRepository.GetPhotoEntityById(photoId, cancellation);
        return _mapper.Map<PhotoDto>(photoEntity);
    }

    /// <inheritdoc />
    public async Task<PhotoDto> CreatePhoto(PhotoDto photoDto, CancellationToken cancellation)
    {
        var photoEntity = _mapper.Map<PhotoEntity>(photoDto);
        var id = await _photoRepository.AddPhotoEntity(photoEntity, cancellation);
        photoDto.Id = id;
        return photoDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<PhotoDto>> GetFilterPhotos(PhotoFilterRequest? photoFilter, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<PhotoEntity>, IEnumerable<PhotoDto>>(await _photoRepository.GetFilterPhotoEntities(photoFilter, cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<PhotoDto>> GetAllPhotos(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<PhotoEntity>, IEnumerable<PhotoDto>>(await _photoRepository.GetAllPhotoEntities(cancellation));
    }

    /// <inheritdoc />
    public async Task DeletePhoto(int photoId, CancellationToken cancellation)
    {
        await _photoRepository.DeletePhotoEntity(photoId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdatePhoto(int photoId, PhotoDto photoDto, CancellationToken cancellation)
    {
        photoDto.Id = photoId;
        var photo= _mapper.Map<PhotoEntity>(photoDto);
        await _photoRepository.UpdatePhotoEntity(photo, cancellation);
    }
}