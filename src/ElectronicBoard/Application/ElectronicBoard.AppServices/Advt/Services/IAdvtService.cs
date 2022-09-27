using ElectronicBoard.Contracts;
using ElectronicBoard.Contracts.Dto;
using ElectronicBoard.Contracts.Dto.Filters;

namespace ElectronicBoard.AppServices.Advt.Services;

/// <summary>
/// Сервис для работы с объявлениями.
/// </summary>
public interface IAdvtService
{
    public Task<AdvtDto> GetById(int id);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="take"></param>
    /// <param name="skip"></param>
    /// <returns></returns>
    /*Task<IReadOnlyCollection<AdvtDto>> GetAll(int take, int skip);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="filterRequest"></param>
    /// <returns></returns>
    Task<IReadOnlyCollection<AdvtDto>> GetAllFiltered(AdvtFilterRequest filterRequest);*/
}