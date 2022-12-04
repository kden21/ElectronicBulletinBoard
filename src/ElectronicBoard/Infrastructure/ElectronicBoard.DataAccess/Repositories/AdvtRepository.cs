using ElectronicBoard.AppServices.Advt.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Advt.Dto;
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
        IQueryable<AdvtEntity> query;
        if (advtFilter.UserVoter.HasValue)
        {
            query = _repository.GetAllEntities()
                .Include(a=>a.UsersVoters)
                .Include(a=>a.Photos.OrderBy(p=>p.Id))
                .Where(a => a.Status == advtFilter.Status);
            
            query = query.Where(a => a.UsersVoters.FirstOrDefault(u=>u.Id == advtFilter.UserVoter).Id==advtFilter.UserVoter);
        }
        else
        {
            query = _repository.GetAllEntities().Include(a=>a.Category)
                .Include(a=>a.Photos.OrderBy(p=>p.Id))
                .Where(a => a.Status == advtFilter.Status);
        }
        

        if (!string.IsNullOrWhiteSpace(advtFilter.Description))
        {
            query = query.Where(a =>
                a.Name.ToLower().Contains(advtFilter.Description.ToLower()));
        }

        if (advtFilter.Photo == true)
            query = query.Where((a => a.Photos.Count != 0));
        
        if (!string.IsNullOrWhiteSpace(advtFilter.Location))
            query = query.Where(a => a.Location.ToLower().Contains(advtFilter.Location.ToLower()));
        if (advtFilter.CategoryId.HasValue)
            query = query.Where(a => (a.Category.ParentCategoryId == advtFilter.CategoryId)||(a.CategoryId==advtFilter.CategoryId));
        if (advtFilter.UserId.HasValue)
            query = query.Where(a => a.AuthorId == advtFilter.UserId);
        
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
    public async Task<AdvtEntity> GetAdvtEntityByIdIncludeAccount(int advtId, CancellationToken cancellation)
    {
        return await _repository.Where(a => a.Id == advtId).Include(a => a.AuthorId).FirstOrDefaultAsync();
    }

    public async Task<AdvtEntity> GetAdvtEntityByIdIncludeUserVoters(int advtId, CancellationToken cancellation)
    {
        return await _repository.Where(a => a.Id == advtId).Include(a => a.UsersVoters).FirstOrDefaultAsync();
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
        var advtEntity = await _repository.GetEntityById(advtModel.Id, cancellation);
        advtModel.CreateDate = advtEntity.CreateDate;
        advtEntity.Description = advtModel.Description;
        advtEntity.Name= advtModel.Name;
        advtEntity.Price = advtModel.Price;
        
        await _repository.UpdateEntity(advtEntity, cancellation);
    }

    /// <inheritdoc />
    public async Task DeleteAdvtEntity(int advtId, CancellationToken cancellation)
    {
        await _repository.DeleteEntity(advtId, cancellation);
    }
    
    /// <inheritdoc />
    public async Task SoftDeleteAdvtEntity(int advtId, CancellationToken cancellation)
    {
        var advt = await _repository.GetEntityById(advtId, cancellation);
        advt.Status = StatusAdvt.Archive;
        await _repository.UpdateEntity(advt, cancellation);
    }
}