namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

public sealed class ReconciliationAct
{
    public int Uid { get; set; }
    public int ReconciliationActFileRootUid { get; set; }

    public int Year { get; set; }
    public short Quarter { get; set; }
    public string ActNumber { get; set; } = string.Empty;
    public DateOnly ActDate { get; set; }
    public string MedicalCareOkatoCode { get; set; } = string.Empty;
    public string PolicyIssueOkatoCode { get; set; } = string.Empty;

    public ReconciliationActFileRoot ReconciliationActFileRoot { get; set; } = null!;
}
