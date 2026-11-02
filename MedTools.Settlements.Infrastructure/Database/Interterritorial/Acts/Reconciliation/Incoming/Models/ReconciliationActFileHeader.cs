namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming.Models;

public sealed class ReconciliationActFileHeader
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public string Version { get; set; } = string.Empty;
    public DateTime ActDate { get; set; }
    public string Filename { get; set; } = string.Empty;

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
}
