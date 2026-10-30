using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Application.Services.Repositories;

public interface IReconciliationActRepository
{
    public Task SaveAsync(
        IReadOnlyCollection<ReconciliationActFileRoot> xmlModel,
        CancellationToken cancellationToken);

}
