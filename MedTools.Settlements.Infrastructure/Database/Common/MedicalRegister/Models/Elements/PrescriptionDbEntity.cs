namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class PrescriptionDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public int SequenceNumber { get; set; }
    public byte PrescriptionType { get; set; }
    public string? PhysicianSpecialty { get; set; }
    public byte? DiagnosticMethod { get; set; }
    public int? MedicalCareProfile { get; set; }
    public string? BedProfile { get; set; }
    public string? ServiceCode { get; set; }
    public DateTime? ReferralDate { get; set; }
    public string? ReferredToMoCode { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
}
