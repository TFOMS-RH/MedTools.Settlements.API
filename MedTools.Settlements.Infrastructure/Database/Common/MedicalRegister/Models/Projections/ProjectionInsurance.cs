namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionInsurance(
    string? InsuranceCompanyCode,
    string? InsuranceCompanyName,
    string? OGRN,
    string? OKATO,
    string? InsurancePolicyUnifiedNumber,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    byte InsurancePolicyTypeCode,
    string InsurancePolicyTypeName);
