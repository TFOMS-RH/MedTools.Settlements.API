namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class SanctionDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }
    public int SanctionDetailsUid { get; set; }

    public string SanctionCode { get; set; } = string.Empty;
    public decimal SanctionAmount { get; set; }
    public string ControlTypeCode { get; set; } = string.Empty;
    public int RefusalReasonCode { get; set; }
    public string? Comment { get; set; }
    public short Source { get; set; }
    public decimal UnitsRemoved { get; set; }
    public string? ClinicalStatisticalGroupNumber { get; set; }
    public string ExpertiseActNumber { get; set; } = string.Empty;
    public DateTime ExpertiseActDate { get; set; }
    public string? ExpertCode { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;

}