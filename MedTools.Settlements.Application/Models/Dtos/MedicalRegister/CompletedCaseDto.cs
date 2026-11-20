namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record CompletedCaseDto(
    int CompletedCaseUid,
    string? MedicalOrganizationCode,
    string? InsuranceOrganizationCode,
    long EntryNumber,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount,
    int MedicalCareConditionsCode,
    string? MedicalCareConditionsName,
    string PatientLastName,
    string PatientFirstName,
    string PatientMiddleName,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    DateTime? TreatmentStartDate,
    DateTime? TreatmentEndDate,
    long EntryPositionNumber);
