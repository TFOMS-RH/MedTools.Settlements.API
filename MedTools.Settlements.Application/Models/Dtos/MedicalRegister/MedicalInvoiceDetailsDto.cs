namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record MedicalInvoiceDetailsDto(
    int InvoiceUid,
    string? Filename,
    DateTime? InvoiceUploadDate,
    decimal InvoiceAmount,
    decimal? ApprovedAmount,
    decimal? MedicalEconomicControlPenalty,
    decimal? MedicalEconomicExpertisePenalty,
    decimal? MedicalCareQualityExpertisePenalty,
    decimal? InsuranceCompanyApprovedAmount,
    decimal? InsuranceCompanyMedicalEconomicControlPenalty,
    decimal? InsuranceCompanyMedicalEconomicExpertisePenalty,
    decimal? InsuranceCompanyMedicalCareQualityExpertisePenalty);
