namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record CompletedCaseDto(
    int CompletedCaseUid,
    long EntryNumber,
    decimal AmountBilled,
    decimal? ApprovedAmount,
    decimal? InsuranceCompanyApprovedAmount,
    int MedicalCareConditionsCode,
    string MedicalCareConditionsName,
    string PatientLastName,
    string PatientFirstName,
    string PatientMiddleName,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    long EntryPositionNumber);
