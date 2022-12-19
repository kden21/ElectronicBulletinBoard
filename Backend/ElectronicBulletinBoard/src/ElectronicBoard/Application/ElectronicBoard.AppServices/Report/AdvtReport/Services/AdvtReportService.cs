using AutoMapper;
using ElectronicBoard.AppServices.Report.AdvtReport.Repositories;
using ElectronicBoard.Contracts.Report.AdvtReport.Dto;
using ElectronicBoard.Contracts.Shared.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Report.AdvtReport.Services;

/// <inheritdoc />
public class AdvtReportService : IAdvtReportService
{
    private readonly IAdvtReportRepository _advtReportRepository;
    private readonly IMapper _mapper;

    public AdvtReportService(IAdvtReportRepository advtReportRepository, IMapper mapper)
    {
        _advtReportRepository = advtReportRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<AdvtReportDto> GetAdvtReportById(int advtReportId, CancellationToken cancellation)
    {
        var advtReportEntity = await _advtReportRepository.GetAdvtReportEntityById(advtReportId, cancellation);
        return _mapper.Map<AdvtReportDto>(advtReportEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtReportDto> CreateAdvtReport(AdvtReportDto advtReportDto, CancellationToken cancellation)
    {
        var advtReportEntity = _mapper.Map<AdvtReportEntity>(advtReportDto);
        var id = await _advtReportRepository.AddAdvtReportEntity(advtReportEntity, cancellation);
        advtReportDto.Id = id;
        return advtReportDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReportDto>> GetAllAdvtReports(CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtReportEntity>, IEnumerable<AdvtReportDto>>(await _advtReportRepository.GetAllAdvtReportEntities(cancellation));
    }
    
    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReportDto>> GetFilterAdvtReports(AdvtReportFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<AdvtReportEntity>, IEnumerable<AdvtReportDto>>(await _advtReportRepository.GetFilterAdvtReportEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReport(int advtReportId, CancellationToken cancellation)
    {
        await _advtReportRepository.DeleteAdvtReportEntity(advtReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReport(int advtReportId, AdvtReportDto advtReportDto, CancellationToken cancellation)
    {
        advtReportDto.Id = advtReportId;
        var advtReport = _mapper.Map<AdvtReportEntity>(advtReportDto);
        await _advtReportRepository.UpdateAdvtReportEntity(advtReport, cancellation);
    }
}