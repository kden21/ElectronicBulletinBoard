using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess.Interfaces;

/// <summary>
/// Конфигуратор контекста.
/// </summary>
public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
{
    /// <summary>
    /// Выполняет конфигурацию контекста.
    /// </summary>
    /// <param name="options">Настройки.</param>
    void Configure(DbContextOptionsBuilder<TContext> options);
}