using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.References;

public sealed class ReferenceDataDbContext(DbContextOptions<ReferenceDataDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ReferenceDataDbContext).Assembly,
            type => type.Namespace?.StartsWith(
                value: "MedTools.Settlements.Infrastructure.Database.References.Configurations",
                comparisonType: StringComparison.Ordinal) == true);
    }
}
