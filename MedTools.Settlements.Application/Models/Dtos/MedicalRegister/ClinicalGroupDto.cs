namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record ClinicalGroupDto(
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
