using AutoMapper;

using MedTools.Settlements.Domain.Enums;
using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Infrastructure.Services.Repositories;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

using Incoming = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming;
using Outgoing = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing;

namespace MedTools.Settlements.Infrastructure.Services;

public sealed class ActsImportService(
    ReconciliationActRepository reconciliationActRepository,
    IMapper mapper) : IActsImportService
{
    public async Task ImportReconciliationActsAsync(
        IReadOnlyCollection<ReconciliationActFileRoot> xmlModels,
        Direction direction,
        CancellationToken cancellationToken)
    {
        switch (direction)
        {
            case Direction.Incoming:

                var incomingReconciliationActs = new List<Incoming.Models.ReconciliationActFileRoot>();

                foreach (var xmlModel in xmlModels)
                {
                    var dbEntity = mapper.Map<Incoming.Models.ReconciliationActFileRoot>(xmlModel);
                    incomingReconciliationActs.Add(dbEntity);
                }

                if (incomingReconciliationActs.Count == 0) throw new Exception();

                await reconciliationActRepository.SaveIncomingReconciliationActAsync(
                    incomingReconciliationActs,
                    cancellationToken: cancellationToken);

                break;

            case Direction.Outgoing:

                var outgoingReconciliationActs = new List<Outgoing.Models.ReconciliationActFileRoot>();

                foreach (var xmlModel in xmlModels)
                {
                    var dbEntity = mapper.Map<Outgoing.Models.ReconciliationActFileRoot>(xmlModel);
                    outgoingReconciliationActs.Add(dbEntity);
                }

                if (outgoingReconciliationActs.Count == 0) throw new Exception();

                await reconciliationActRepository.SaveOutgoingReconciliationActAsync(
                    outgoingReconciliationActs,
                    cancellationToken: cancellationToken);

                break;

            default:
                throw new IndexOutOfRangeException();
        }
    }
}
