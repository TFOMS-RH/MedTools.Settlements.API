using MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

public sealed class ReconciliationActRecord
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public int RecordNumber { get; set; }

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
    public InvoiceSettlement InvoiceSettlement { get; set; } = null!;

}
