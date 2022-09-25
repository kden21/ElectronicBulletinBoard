using ElectronicBoard.DataAccess.EntityConfigurations.Advt;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess;

public class ElectronicBoardContext : DbContext
{
    public ElectronicBoardContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AdvtConfiguration());
    }
}