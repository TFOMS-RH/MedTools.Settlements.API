namespace MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct.Models;

public sealed class InvoiceSettlement
{
    public int Uid { get; set; }
    public int ReconciliationActRecordUid { get; set; }

    public string InvoiceNumber { get; set; } = string.Empty;
    public DateOnly InvoiceDate { get; set; }
    public decimal OpeningBalance { get; set; }
    public decimal MedicalCarePaymentAmount { get; set; }
    public decimal RecoveryNoticeAmount { get; set; }
    public decimal RefundNoticeAmount { get; set; }
    public decimal TransferFromInsurancePlaceAmount { get; set; }
    public decimal TransferFromCarePlaceAmount { get; set; }
    public decimal ClosingBalance { get; set; }

    public ReconciliationActRecord ReconciliationActRecord { get; set; } = null!;
}
