using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class InvoiceDbEntity
{
    public int Uid { get; set; }
    public int MedicalRegistryUid { get; set; }

    public long InvoiceCode { get; set; }
    public string MedicalOrganizationCode { get; set; } = string.Empty;
    public int BillingYear { get; set; }
    public byte BillingMonth { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;
    public DateTime InvoiceBillingDate { get; set; }
    public string? PayerCode { get; set; }
    public decimal InvoiceAmount { get; set; }
    public string? InternalComment { get; set; }
    public decimal? ApprovedAmount { get; set; }
    public decimal? MedicalEconomicControlPenalty { get; set; }
    public decimal? MedicalEconomicExpertisePenalty { get; set; }
    public decimal? MedicalCareQualityExpertisePenalty { get; set; }
    public decimal? InsuranceCompanyApprovedAmount { get; set; }
    public decimal? InsuranceCompanyMedicalEconomicControlPenalty { get; set; }
    public decimal? InsuranceCompanyMedicalEconomicExpertisePenalty { get; set; }
    public decimal? InsuranceCompanyMedicalCareQualityExpertisePenalty { get; set; }
    public string? PreventiveExaminationType { get; set; }

    public MedicalRegistryDbEntity MedicalRegistry { get; set; } = null!;
}
