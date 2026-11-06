namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ClinicalGroupDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public string ClinicalStatisticGroupNumber { get; set; } = string.Empty;
    public int ClinicalStatisticGroupModelVersion { get; set; }
    public byte IsCsgSubgroupUsed { get; set; }
    public string? ClinicalProfileGroupNumber { get; set; }
    public float CostCoefficient { get; set; }
    public float ManagementCoefficient { get; set; }
    public decimal BaseRate { get; set; }
    public float DifferentiationCoefficient { get; set; }
    public float LevelCoefficient { get; set; }
    public string? AdditionalCriterionFirst { get; set; }
    public string? AdditionalCriterionSecond { get; set; }
    public byte IsClspUsed { get; set; }
    public float? ComplexityCoefficient { get; set; }
    public string? CalculatedClinicalStatisticalGroupNumber { get; set; }
    public decimal? WageTargetCoefficient { get; set; }
    public string? InterruptedCasePaymentReason { get; set; }
    public decimal? InterruptedCasePaymentShare { get; set; }

    public MedicalCaseDbEntity MedicalCase { get; set; } = null!;
    public List<TreatmentComplexityCoefficientDbEntity> TreatmentComplexityCoefficients { get; set; } = [];
    public List<ClassificationCriterionDbEntity> ClassificationCriteria { get; set; } = [];
}
