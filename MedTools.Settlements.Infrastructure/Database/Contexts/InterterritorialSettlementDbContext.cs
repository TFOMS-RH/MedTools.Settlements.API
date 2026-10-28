using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace MedTools.Settlements.Infrastructure.Database.Contexts;

public sealed class InterterritorialSettlementDbContext(
    DbContextOptions<InterterritorialSettlementDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}