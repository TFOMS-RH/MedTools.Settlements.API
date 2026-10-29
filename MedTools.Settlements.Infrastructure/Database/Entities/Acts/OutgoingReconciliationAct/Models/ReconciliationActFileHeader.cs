namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

public sealed class ReconciliationActFileHeader
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public string Version { get; set; } = string.Empty;
    public DateOnly ActDate { get; set; }
    public string Filename { get; set; } = string.Empty;

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
}
