namespace MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming.Models;

public sealed class ReconciliationActFileRoot
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short? ActStatus { get; set; }

    public ReconciliationActFileHeader Header { get; set; } = null!;
    public ReconciliationAct Act { get; set; } = null!;
    public List<ReconciliationActRecord> Records { get; set; } = null!;
}
