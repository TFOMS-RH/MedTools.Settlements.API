namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing.Models;

public sealed class ReconciliationActRecord
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public int RecordNumber { get; set; }

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
    public InvoiceSettlement InvoiceSettlement { get; set; } = null!;

}
