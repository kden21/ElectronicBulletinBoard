using AutoMapper;
using ElectronicBoard.AppServices.Repositories.Report;
using ElectronicBoard.Contracts.Dto.Report;
using ElectronicBoard.Contracts.Filters.Report;
using ElectronicBoard.Domain.Report;

namespace ElectronicBoard.AppServices.Services.Report.UserReport;

/// <inheritdoc />
public class UserReportService : IUserReportService
{
    private readonly IUserReportRepository _userReportRepository;
    private readonly IMapper _mapper;

    public UserReportService(IUserReportRepository userReportRepository, IMapper mapper)
    {
        _userReportRepository = userReportRepository;
        _mapper = mapper;
    }

    /// <inheritdoc />
    public async Task<UserReportDto> GetUserReportById(int userReportId, CancellationToken cancellation)
    {
        var userReportEntity = await _userReportRepository.GetUserReportEntityById(userReportId, cancellation);
        return _mapper.Map<UserReportDto>(userReportEntity);
    }

    /// <inheritdoc />
    public async Task<UserReportDto> CreateUserReport(UserReportDto userReportDto, CancellationToken cancellation)
    {
        var userReportEntity = _mapper.Map<UserReportEntity>(userReportDto);
        var id = await _userReportRepository.AddUserReportEntity(userReportEntity, cancellation);
        userReportDto.Id = id;
        return userReportDto;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<UserReportDto>> GetAllUserReports(UserReportFilterRequest? filterRequest, CancellationToken cancellation)
    {
        return _mapper.Map<IEnumerable<UserReportEntity>, IEnumerable<UserReportDto>>(await _userReportRepository.GetAllUserReportEntities(filterRequest, cancellation));
    }

    /// <inheritdoc />
    public async Task DeleteUserReport(int userReportId, CancellationToken cancellation)
    {
        await _userReportRepository.DeleteUserReportEntity(userReportId, cancellation);
    }

    /// <inheritdoc />
    public async Task UpdateUserReport(int userReportId, UserReportDto userReportDto, CancellationToken cancellation)
    {
        userReportDto.Id = userReportId;
        var userReport = _mapper.Map<UserReportEntity>(userReportDto);
        await _userReportRepository.UpdateUserReportEntity(userReport, cancellation);
    }
}