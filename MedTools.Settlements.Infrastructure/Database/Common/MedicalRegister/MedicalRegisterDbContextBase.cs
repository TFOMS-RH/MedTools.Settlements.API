using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;

public abstract class MedicalRegisterDbContextBase(
    DbContextOptions options)
        : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(MedicalRegisterDbContextBase).Assembly,
            type => type.Namespace?.StartsWith(
                value: "MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Configuration",
                comparisonType: StringComparison.Ordinal) == true);
    }
}
