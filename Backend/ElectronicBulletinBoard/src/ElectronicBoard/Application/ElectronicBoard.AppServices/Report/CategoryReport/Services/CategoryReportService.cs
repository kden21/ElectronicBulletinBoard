using AutoMapper;
using ElectronicBoard.AppServices.Report.CategoryReport.Repositories;
using ElectronicBoard.Contracts.Report.CategoryReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.CategoryReport.Services;

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
    public async Task<IEnumerable<CategoryReportDto>> GetAllCategoryReports(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<CategoryReportEntity>, IEnumerable<CategoryReportDto>>(await _сategoryReportRepository.GetAllCategoryReportEntities(cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<CategoryReportDto>> GetFilterCategoryReports(CategoryReportFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<CategoryReportEntity>, IEnumerable<CategoryReportDto>>(await _сategoryReportRepository.GetFilterCategoryReportEntities(filterRequest, cancellation));
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