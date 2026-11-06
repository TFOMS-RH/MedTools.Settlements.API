namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ConsultationDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public byte ConsultationPurposeCode { get; set; }
    public DateTime? ConsultationDate { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
}
