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
    public async Task<CategoryReportDto> GetCategoryReportById(int сategoryReportId, CancellationToken cancellation)
    {
        var сategoryReportEntity = await _сategoryReportRepository.GetCategoryReportEntityById(сategoryReportId, cancellation);
        return _mapper.Map<CategoryReportDto>(сategoryReportEntity);
    }

    /// <inheritdoc />
    public async Task<CategoryReportDto> CreateCategoryReport(CategoryReportDto сategoryReportDto, CancellationToken cancellation)
    {
        var сategoryReportEntity = _mapper.Map<CategoryReportEntity>(сategoryReportDto);
        var id = await _сategoryReportRepository.AddCategoryReportEntity(сategoryReportEntity, cancellation);
        сategoryReportDto.Id = id;
        return сategoryReportDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<CategoryReportDto>> GetAllCategoryReports(CategoryReportFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<CategoryReportEntity>, IEnumerable<CategoryReportDto>>(await _сategoryReportRepository.GetAllCategoryReportEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteCategoryReport(int сategoryReportId, CancellationToken cancellation)
    {
        await _сategoryReportRepository.DeleteCategoryReportEntity(сategoryReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateCategoryReport(int сategoryReportId, CategoryReportDto сategoryReportDto, CancellationToken cancellation)
    {
        сategoryReportDto.Id = сategoryReportId;
        var сategoryReport = _mapper.Map<CategoryReportEntity>(сategoryReportDto);
        await _сategoryReportRepository.UpdateCategoryReportEntity(сategoryReport, cancellation);
    }
}