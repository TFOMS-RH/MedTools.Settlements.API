namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record InsuranceDto(
    string? InsuranceCompanyCode,
    string? InsuranceCompanyName,
    string? OGRN,
    string? OKATO,
    string? InsurancePolicyUnifiedNumber,
    string? InsurancePolicySeries,
    string InsurancePolicyNumber,
    byte InsurancePolicyTypeCode,
    string InsurancePolicyTypeName);
