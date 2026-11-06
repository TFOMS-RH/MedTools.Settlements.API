namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class TreatmentComplexityCoefficientDbEntity
{
    public int Uid { get; set; }
    public int ClinicalGroupUid { get; set; }

    public string? ComplexityCoefficientNumber { get; set; }
    public float ComplexityCoefficientValue { get; set; }

    public ClinicalGroupDbEntity ClinicalGroup { get; set; } = null!;
}