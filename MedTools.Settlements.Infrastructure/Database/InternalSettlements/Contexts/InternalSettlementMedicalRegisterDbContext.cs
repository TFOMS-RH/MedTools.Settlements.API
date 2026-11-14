using Microsoft.EntityFrameworkCore;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.Contexts;

public sealed class InternalSettlementMedicalRegisterDbContext(
    DbContextOptions<InternalSettlementMedicalRegisterDbContext> options) 
        : MedicalRegisterDbContextBase(options);
