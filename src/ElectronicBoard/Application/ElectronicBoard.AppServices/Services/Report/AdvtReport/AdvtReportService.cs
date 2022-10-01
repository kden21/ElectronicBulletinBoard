using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Services.Report.AdvtReport;

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
    public async Task<AdvtReportDto> GetAdvtReportById(int advtReportId)
    {
        var advtReportEntity = await _advtReportRepository.GetAdvtReportEntityById(advtReportId);
        return _mapper.Map<AdvtReportDto>(advtReportEntity);
    }

    /// <inheritdoc />
    public async Task<AdvtReportDto> CreateAdvtReport(AdvtReportDto advtReportDto)
    {
        var advtReportEntity = _mapper.Map<AdvtReportEntity>(advtReportDto);
        var id = await _advtReportRepository.AddAdvtReportEntity(advtReportEntity);
        advtReportDto.Id = id;
        return advtReportDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<AdvtReportDto>> GetAllAdvtReports(AdvtReportFilterRequest? filterRequest)
    {
        return _mapper.Map<IEnumerable<AdvtReportEntity>, IEnumerable<AdvtReportDto>>(await _advtReportRepository.GetAllAdvtReportEntities(filterRequest));
    }

    /// <inheritdoc />
    public async Task DeleteAdvtReport(int advtReportId)
    {
        await _advtReportRepository.DeleteAdvtReportEntity(advtReportId);
    }

    /// <inheritdoc />
    public async Task UpdateAdvtReport(int advtReportId, AdvtReportDto advtReportDto)
    {
        advtReportDto.Id = advtReportId;
        var advtReport = _mapper.Map<AdvtReportEntity>(advtReportDto);
        await _advtReportRepository.UpdateAdvtReportEntity(advtReport);
    }
}