namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class DiagnosticDbEntity
{
    public int Uid { get; set; }
    public int OncologyCaseUid { get; set; }

    public byte? DiagnosticType { get; set; }
    public int? DiagnosticCode { get; set; }
    public int? DiagnosticResultCode { get; set; }
    public DateTime? SpecimenCollectionDate { get; set; }
    public byte? IsResultReceived { get; set; }

    public OncologyCaseDbEntity OncologyCase { get; set; } = null!;
}