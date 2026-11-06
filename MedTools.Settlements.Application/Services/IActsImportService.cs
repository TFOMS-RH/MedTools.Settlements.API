using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Application.Services;

public interface IActsImportService
{
    public Task ImportReconciliationActsAsync(
        IReadOnlyCollection<ReconciliationActFileRoot> xmlModels,
        Direction direction,
        CancellationToken cancellationToken);
}
