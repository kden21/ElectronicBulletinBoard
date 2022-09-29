using System.Linq.Expressions;
using ElectronicBoard.AppServices.Repositories;
using ElectronicBoard.AppServices.Shared.Repository;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Dto.Filters;
using ElectronicBoard.DataAccess.Repositories.Shared;
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
    public IQueryable<AdvtEntity> GetAll()
    {
       return _repository.GetAll();
    }

    /// <inheritdoc />
    public IEnumerable<AdvtEntity> GetAllFiltered(AdvtFilterRequest filterRequest)
    {
        var query = _repository.GetAll();
        if (filterRequest.Id.HasValue)
            query = query.Where(a => a.Id == filterRequest.Id);
        if (!string.IsNullOrWhiteSpace(filterRequest.Name))
            query = query.Where(a => a.Name.ToLower().Contains(filterRequest.Name.ToLower()));
        if (filterRequest.CategoryId.HasValue)
            query = query.Where(a => a.CategoryId == filterRequest.CategoryId);
        if (filterRequest.UserId.HasValue)
            query = query.Where(a => a.UserId == filterRequest.UserId);
        return query.OrderBy(a=>a.Id).Skip(filterRequest.Offset).Take(filterRequest.Count);
    }
    
    /// <inheritdoc />
    public async Task<AdvtEntity> GetByIdAsync(int advtId)
    {
        return await _repository.GetByIdAsync(advtId);
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(AdvtEntity advtModel)
    {
        await _repository.AddAsync(advtModel);
        return advtModel.Id;
    }

    /// <inheritdoc />
    public async Task UpdateAsync(AdvtEntity advtModel)
    {
        await _repository.UpdateAsync(advtModel);
    }

    /// <inheritdoc />
    public async Task DeleteAsync(int advtId)
    {
        await _repository.DeleteAsync(advtId);
    }
}