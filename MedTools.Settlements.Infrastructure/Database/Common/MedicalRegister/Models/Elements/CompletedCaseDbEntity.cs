namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class CompletedCaseDbEntity
{
    public int Uid { get; set; }
    public int MedicalRecordUid { get; set; }

    public long CaseRecordNumber { get; set; }
    public int CareCondition { get; set; }
    public int MedicalCareType { get; set; }
    public byte CareForm { get; set; }
    public string? ReferringMedicalOrganizationCode { get; set; }
    public DateTime? ReferralDate { get; set; }
    public string MedicalOrganizationCode { get; set; } = string.Empty;
    public byte? IsMobileTeam { get; set; }
    public DateTime TreatmentStartDate { get; set; }
    public DateTime TreatmentEndDate { get; set; }
    public byte? IsRefusal { get; set; }
    public int? ScreeningResult { get; set; }
    public int? HospitalizationDuration { get; set; }
    public int? BirthWeight { get; set; }
    public int HospitalizationOutcome { get; set; }
    public int DiseaseOutcome { get; set; }
    public byte? IsSpecialCase { get; set; }
    public byte? IsIntrahospitalTransfer { get; set; }
    public short PaymentMethodCode { get; set; }
    public decimal BilledAmount { get; set; }
    public byte? PaymentType { get; set; }
    public decimal? ApprovedAmount { get; set; }
    public decimal? InsuranceCompanyApprovedAmount { get; set; }
    public decimal? PenaltyAmount { get; set; }
    public decimal? InsuranceCompanyPenaltyAmount { get; set; }
    public byte? IsEveningVisit { get; set; }
    public string? ReferralNumber { get; set; }

    public MedicalRecordDbEntity MedicalRecord { get; set; } = null!;
    public List<MedicalCaseDbEntity> MedicalCases { get; set; } = null!;
}
