namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionMedicalCase(
    int MedicalCaseUid,
    int MedicalProfileCode,
    string MedicalProfileName,
    bool IsPediatric,
    int PhysicianSpecialtyCode,
    string PhysicianSpecialtyName,
    DateTime TreatmentStartDate,
    DateTime TreatmentEndDate,
    string PrimaryDiagnosisCode,
    string? PrimaryDiagnosisName,
    decimal? PaidUnits,
    decimal? UnitRate,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount);
