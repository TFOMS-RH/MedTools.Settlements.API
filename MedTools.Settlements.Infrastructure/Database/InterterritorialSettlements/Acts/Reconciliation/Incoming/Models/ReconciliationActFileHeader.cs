namespace MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming.Models;

public sealed class ReconciliationActFileHeader
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public string? Version { get; set; }
    public DateTime? FileDate { get; set; }
    public string? Filename { get; set; }

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
}
