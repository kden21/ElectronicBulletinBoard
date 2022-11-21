using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Shared.Enums;
using ElectronicBoard.Contracts.Shared.Filters;
using ElectronicBoard.Domain;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Repositories;

public class AdvtRepository : IAdvtRepository
{
    private readonly IRepository<AdvtEntity> _repository;

    public AdvtRepository(IRepository<AdvtEntity> repository)
    {
        _repository = repository;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtEntity>> GetFilterAdvtEntities(AdvtFilterRequest? advtFilter, CancellationToken cancellation)
    {
        IQueryable<AdvtEntity> query = _repository.GetAllEntities().Include(a=>a.Category)
            .Where(a => a.Status == advtFilter.Status);

       
        if (!string.IsNullOrWhiteSpace(advtFilter.Description))
        {
            query = query.Where(a =>
                (a.Description.ToLower().Contains(advtFilter.Description.ToLower())) ||
                (a.Name.ToLower().Contains(advtFilter.Description.ToLower())));
        }
        
        if (!string.IsNullOrWhiteSpace(advtFilter.Location))
            query = query.Where(a => a.Location.ToLower().Contains(advtFilter.Location.ToLower()));
        if (advtFilter.CategoryId.HasValue)
            query = query.Where(a => (a.Category.ParentCategoryId == advtFilter.CategoryId)||(a.CategoryId==advtFilter.CategoryId));
        if (advtFilter.UserId.HasValue)
            query = query.Where(a => a.UserId == advtFilter.UserId);
        
              if(advtFilter.LastAdvtId.HasValue)
                 query = query.Where(a => a.Id < advtFilter.LastAdvtId);
              return await query.OrderByDescending(a=>a.CreateDate)
                  .Take(advtFilter.Count==0?16:advtFilter.Count)
            .ToListAsync(cancellation);
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtEntity>> GetAllAdvtEntities(CancellationToken cancellation)
    {
        return _repository.GetAllEntities().Where(a=>a.Status==StatusAdvt.Actual).OrderByDescending(a => a.CreateDate);
    }
    
    /// <inheritdoc />
    public async Task<AdvtEntity> GetAdvtEntityById(int advtId, CancellationToken cancellation)
    {
        return await _repository.GetEntityById(advtId, cancellation);
    }

    /// <inheritdoc />
    public async Task<int> AddAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation)
    {
        await _repository.AddEntity(advtModel, cancellation);
        return advtModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAdvtEntity(AdvtEntity advtModel, CancellationToken cancellation)
    {
        await _repository.UpdateEntity(advtModel, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtEntity(int advtId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtId, cancellation);
    }
}