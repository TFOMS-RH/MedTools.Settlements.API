namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionClinicalGroup(
    int ClinicalGroupUid,
    string ClinicalStatisticalGroupNumber,
    string? CalculatedClinicalStatisticalGroupNumber,
    int ClinicalStatisticalGroupModelVersion,
    bool IsCsgSubgroupUsed,
    string? ClinicalProfileGroupNumber,
    float CostCoefficient,
    float ManagementCoefficient,
    decimal BaseRate,
    float DifferentiationCoefficient,
    float LevelCoefficient,
    decimal? WageTargetCoefficient,
    bool IsClspUsed,
    float? ComplexityCoefficient);
