using MedTools.Settlements.Infrastructure.Database.Contexts;

using Incoming = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming;
using Outgoing = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing;

namespace MedTools.Settlements.Infrastructure.Services.Repositories;

public sealed class ReconciliationActRepository(InterterritorialSettlementDbContext dbContext)
{
    public async Task SaveOutgoingReconciliationActAsync(
        IReadOnlyCollection<Outgoing.Models.ReconciliationActFileRoot> actRoots,
        CancellationToken cancellationToken)
    {
        if(actRoots.Count  == 0) return;

        await dbContext
            .Set<Outgoing.Models.ReconciliationActFileRoot>()
            .AddRangeAsync(
                entities: actRoots,
                cancellationToken: cancellationToken);

        await dbContext.SaveChangesAsync(
            cancellationToken: cancellationToken);
    }

    public async Task SaveIncomingReconciliationActAsync(
        IReadOnlyCollection<Incoming.Models.ReconciliationActFileRoot> actRoots,
        CancellationToken cancellationToken)
    {
        if (actRoots.Count == 0) return;

        await dbContext
            .Set<Incoming.Models.ReconciliationActFileRoot>()
            .AddRangeAsync(
                entities: actRoots,
                cancellationToken: cancellationToken);

        await dbContext.SaveChangesAsync(
            cancellationToken: cancellationToken);
    }
}
