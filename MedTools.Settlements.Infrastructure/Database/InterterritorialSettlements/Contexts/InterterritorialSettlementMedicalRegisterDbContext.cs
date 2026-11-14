using Microsoft.EntityFrameworkCore;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;

namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

public sealed class InterterritorialSettlementMedicalRegisterDbContext(
    DbContextOptions<InterterritorialSettlementMedicalRegisterDbContext> options)
        : MedicalRegisterDbContextBase(options);
