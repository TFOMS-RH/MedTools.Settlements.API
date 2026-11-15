using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.Contexts;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class MedicalRegisterDbContextResolver(
    InternalSettlementMedicalRegisterDbContext internalSettlementMedicalRegisterDbContext,
    InterterritorialSettlementMedicalRegisterDbContext interterritorialSettlementMedicalRegisterDbContext)
{
    public MedicalRegisterDbContextBase GetDbContext(
        MedicalRegisterType registerType)
    {
        return registerType switch
        {
            MedicalRegisterType.Internal => internalSettlementMedicalRegisterDbContext,
            MedicalRegisterType.Interterritorial => interterritorialSettlementMedicalRegisterDbContext,
            _ => throw new ArgumentOutOfRangeException(
                    nameof(registerType),
                    registerType,
                    "Неподдерживаемый тип медицинского реестра.")
        };
    }
}
