using System.Linq;
using ElectronicBoard.AppServices.Photo.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

public class PhotoRepository: IPhotoRepository 
{
    private readonly IRepository<PhotoEntity> _repository;

    public PhotoRepository(IRepository<PhotoEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<PhotoEntity>> GetFilterPhotoEntities(PhotoFilterRequest? photoFilter, CancellationToken cancellation)
    {
        var query = _repository.GetAllEntities().OrderBy(c => c.Id);
        return await query
            .Where(p=>p.AdvtId==photoFilter.AdvtId)
            .ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<PhotoEntity>> GetAllPhotoEntities(CancellationToken cancellation)
    {
        return await _repository.GetAllEntities().ToListAsync(cancellation);
    }

    /// <inheritdoc />
    public async Task<PhotoEntity?> GetPhotoEntityById(int photoId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(photoId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddPhotoEntity(PhotoEntity photoModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(photoModel, cancellation);
        return photoModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdatePhotoEntity(PhotoEntity photoModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(photoModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeletePhotoEntity(int photoId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(photoId, cancellation);
    }
}