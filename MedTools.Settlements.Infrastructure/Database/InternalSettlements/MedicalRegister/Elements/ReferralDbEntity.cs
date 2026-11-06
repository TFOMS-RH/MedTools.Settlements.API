namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ReferralDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public DateTime ReferralDate { get; set; }
    public byte ReferralType { get; set; }
    public byte? DiagnosticMethod { get; set; }
    public string? ReferredServiceCode { get; set; }
    public string? ReferredToMoCode { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
}