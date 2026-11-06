namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class TreatmentComplexityCoefficientDbEntity
{
    public int Uid { get; set; }
    public int ClinicalGroupUid { get; set; }

    public string? ComplexityCoefficientNumber { get; set; }
    public float ComplexityCoefficientValue { get; set; }

    public ClinicalGroupDbEntity ClinicalGroup { get; set; } = null!;
}