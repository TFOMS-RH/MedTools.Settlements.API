namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public record class MedicalCaseDto(
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
