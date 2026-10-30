using AutoMapper;

using MedTools.Settlements.Infrastructure.Database.Contexts;
using MedTools.Settlements.Application.Services.Repositories;

using XmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using DbEntityOutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct;

namespace MedTools.Settlements.Infrastructure.Services.Repositories;

public sealed class ReconciliationActRepository(
    IMapper mapper,
    InterterritorialSettlementDbContext dbContext) : IReconciliationActRepository
{
    public async Task SaveAsync(
        IReadOnlyCollection<XmlReconciliationAct.ReconciliationActFileRoot> xmlModels,
        CancellationToken cancellationToken)
    {
        var mapEntities = new List<DbEntityOutgoingReconciliationAct.Models.ReconciliationActFileRoot>();

        foreach (var xmlModel in xmlModels)
        {
            var mapEntity = mapper
                .Map<DbEntityOutgoingReconciliationAct.Models.ReconciliationActFileRoot>(xmlModel);

            if (mapEntity is null) continue;

            mapEntities.Add(mapEntity);
        }

        await dbContext
            .Set<DbEntityOutgoingReconciliationAct.Models.ReconciliationActFileRoot>()
            .AddRangeAsync(
                mapEntities,
                cancellationToken: cancellationToken);

        await dbContext.SaveChangesAsync(
            cancellationToken: cancellationToken);
    }
    
}
