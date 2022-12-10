using ElectronicBoard.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ElectronicBoard.DataAccess;

public class ElectronicBoardContextConfiguration : IDbContextOptionsConfigurator<ElectronicBoardContext>
{
    private const string ConnectionStringName = "ElectronicBoardDb";
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public ElectronicBoardContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
    {
        _loggerFactory = loggerFactory;
        _configuration = configuration;
    }

    public void Configure(DbContextOptionsBuilder<ElectronicBoardContext> options)
    {
        string connectionString = _configuration.GetConnectionString(ConnectionStringName);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException(
                $"Не найдена строка подключения с именем '{ConnectionStringName}'");
        }
        
        options
            .UseNpgsql(connectionString)
            .UseLoggerFactory(_loggerFactory);
    }
}
