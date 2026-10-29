namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct.Models;

public sealed class ReconciliationActFileRoot
{
    public int Uid { get; set; }

    public DateOnly UploadDate { get; set; }
    public string Uploader { get; set; } = string.Empty;
    public short ActStatus { get; set; }

    public ReconciliationActFileHeader Header { get; set; } = null!;
    public ReconciliationAct Act { get; set; } = null!;
    public List<ReconciliationActRecord> Records { get; set; } = null!;
}
