using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Services.Report.CategoryReport;

/// <inheritdoc />
public class CategoryReportService : ICategoryReportService
{
    private readonly ICategoryReportRepository _сategoryReportRepository;
    private readonly IMapper _mapper;

    public CategoryReportService(ICategoryReportRepository сategoryReportRepository, IMapper mapper)
    {
        _сategoryReportRepository = сategoryReportRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<CategoryReportDto> GetCategoryReportById(int сategoryReportId)
    {
        var сategoryReportEntity = await _сategoryReportRepository.GetCategoryReportEntityById(сategoryReportId);
        return _mapper.Map<CategoryReportDto>(сategoryReportEntity);
    }

    /// <inheritdoc />
    public async Task<CategoryReportDto> CreateCategoryReport(CategoryReportDto сategoryReportDto)
    {
        var сategoryReportEntity = _mapper.Map<CategoryReportEntity>(сategoryReportDto);
        var id = await _сategoryReportRepository.AddCategoryReportEntity(сategoryReportEntity);
        сategoryReportDto.Id = id;
        return сategoryReportDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryReportDto>> GetAllCategoryReports(CategoryReportFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<CategoryReportEntity>, IEnumerable<CategoryReportDto>>(await _сategoryReportRepository.GetAllCategoryReportEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteCategoryReport(int сategoryReportId)
    {
        await _сategoryReportRepository.DeleteCategoryReportEntity(сategoryReportId);
    }

    /// <inheritdoc />
    public async Task UpdateCategoryReport(int сategoryReportId, CategoryReportDto сategoryReportDto)
    {
        сategoryReportDto.Id = сategoryReportId;
        var сategoryReport = _mapper.Map<CategoryReportEntity>(сategoryReportDto);
        await _сategoryReportRepository.UpdateCategoryReportEntity(сategoryReport);
    }
}