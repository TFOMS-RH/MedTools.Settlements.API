namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class PatientDbEntity
{
    public int Uid { get; set; }
    public string PatientRecordCode { get; set; } = string.Empty;
    public byte InsurancePolicyType { get; set; }
    public string? InsurancePolicySeries { get; set; }
    public string InsurancePolicyNumber { get; set; } = string.Empty;
    public string? InsurancePolicyUnifiedNumber { get; set; }
    public string? InsuranceRegionCode { get; set; }
    public string? InsuranceCompanyCode { get; set; }
    public string? InsuranceOrganizationOgrn { get; set; }
    public string? InsuranceTerritoryOkato { get; set; }
    public string? InsuranceCompanyName { get; set; }
    public byte? DisabilityGroup { get; set; }
    public byte? MedicoSocialExaminationReferral { get; set; }
    public string NewbornIdentifier { get; set; } = string.Empty;
    public int? BirthWeight { get; set; }
    public string? SocialCategory { get; set; }
    public int? NextScheduledExaminationMonth { get; set; }
    public string? PrimaryCareMedicalOrganizationCode { get; set; }
    public string? EmploymentType { get; set; }
    public int? PatientStatus { get; set; }

    public MedicalRecordDbEntity MedicalRecord { get; set; } = null!;
}
