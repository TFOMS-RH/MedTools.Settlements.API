using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

public sealed class InterterritorialSettlementDbContext(
    DbContextOptions<InterterritorialSettlementDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(InterterritorialSettlementDbContext).Assembly,
            type => type.Namespace?.StartsWith(
                "MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation",
                comparisonType: StringComparison.Ordinal) == true);
    }
}