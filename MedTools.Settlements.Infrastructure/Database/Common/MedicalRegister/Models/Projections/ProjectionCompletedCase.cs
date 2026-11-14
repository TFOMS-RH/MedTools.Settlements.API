namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionCompletedCase(
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
