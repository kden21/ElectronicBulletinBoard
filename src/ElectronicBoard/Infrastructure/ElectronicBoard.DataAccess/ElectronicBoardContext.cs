using ElectronicBoard.DataAccess.EntityConfigurations;
using ElectronicBoard.DataAccess.EntityConfigurations.Report;
using ElectronicBoard.DataAccess.EntityConfigurations.Review;
using Microsoft.EntityFrameworkCore;

namespace ElectronicBoard.DataAccess;

public class ElectronicBoardContext : DbContext
{
    public ElectronicBoardContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new AdvtEntityConfiguration())
            .ApplyConfiguration(new AccountEntityConfiguration())
            .ApplyConfiguration(new UserEntityConfiguration())
            .ApplyConfiguration(new CategoryEntityConfiguration())
            .ApplyConfiguration(new AdvtReviewEntityConfiguration())
            .ApplyConfiguration(new UserReviewEntityConfiguration())
            .ApplyConfiguration(new CategoryReportEntityConfiguration())
            .ApplyConfiguration(new AdvtReportEntityConfiguration())
            .ApplyConfiguration(new UserReportEntityConfiguration());
    }
}