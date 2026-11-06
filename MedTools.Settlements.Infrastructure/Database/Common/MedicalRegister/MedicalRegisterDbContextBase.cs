using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;

public abstract class MedicalRegisterDbContextBase(
    DbContextOptions options)
        : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
