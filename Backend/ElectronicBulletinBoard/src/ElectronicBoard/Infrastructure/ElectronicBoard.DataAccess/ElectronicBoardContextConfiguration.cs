using ElectronicBoard.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElectronicBoard.DataAccess;

public class ElectronicBoardContextConfiguration : IDbContextOptionsConfigurator<ElectronicBoardContext>
{
    private static string _containerStringVariable = "DOTNET_RUNNING_IN_CONTAINER";
    private static string _connectionStringLocal = "ElectronicBoardDbLocal";
    private static string _connectionStringDocker = "ElectronicBoardDbDocker";
    private static bool _isContainer;
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public ElectronicBoardContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
    {
        _loggerFactory = loggerFactory;
        _configuration = configuration;
    }

    public void Configure(DbContextOptionsBuilder<ElectronicBoardContext> options)
    {
        bool.TryParse(Environment.GetEnvironmentVariable(_containerStringVariable), out _isContainer);
        var connectionString = _configuration.GetConnectionString(_isContainer ? _connectionStringDocker : _connectionStringLocal);
        
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                $"Не найдена строка подключения");
        }
        
        options
            .UseNpgsql(connectionString)
            .UseLoggerFactory(_loggerFactory);
    }
}
