using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;

public abstract class MedicalRegisterDbContextBase(
    DbContextOptions<MedicalRegisterDbContextBase> options)
        : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MedicalRegisterDbContextBase).Assembly);
    }
}
