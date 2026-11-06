using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.Contexts;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

namespace MedTools.Settlements.Infrastructure.Services.Factories;

public sealed class MedToolsSettlementsDbContextFactory(
    IServiceProvider serviceProvider)
{
    public MedicalRegisterDbContextBase CreateDbContext(
        MedicalRegisterType registerType)
    {
        return registerType switch
        {
            MedicalRegisterType.Internal => serviceProvider.GetRequiredService<InternalSettlementMedicalRegisterDbContext>(),
            MedicalRegisterType.Interterritorial => serviceProvider.GetRequiredService<InterterritorialSettlementMedicalRegisterDbContext>(),
            _ => throw new InvalidOperationException()
        };
    }
}
