namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class MedicalCaseDbEntity
{
    public int Uid { get; set; }
    public int CompletedCaseUid { get; set; }

    public string MedicalCaseIdentificator { get; set; } = string.Empty;
    public string? HighTechCareType { get; set; }
    public string? HighTechCareMethod { get; set; }
    public string? Division { get; set; }
    public long? DepartmentCode { get; set; }
    public int MedicalProfile { get; set; }
    public int? BedProfile { get; set; }
    public short IsPediatric { get; set; }
    public DateTime? VoucherIssueDate { get; set; }
    public string? VoucherNumber { get; set; }
    public DateTime? PlannedAdmissionDate { get; set; }
    public string? VisitPurpose { get; set; }
    public string MedicalRecordNumber { get; set; } = string.Empty;
    public short? IsAdmissionTransfer { get; set; }
    public DateTime TreatmentStartDate { get; set; }
    public DateTime TreatmentEndDate { get; set; }
    public int? HospitalizationDuration { get; set; }
    public string? InitialDiagnosis { get; set; }
    public string PrimaryDiagnosis { get; set; } = string.Empty;
    public byte? IsPrimaryDiagnosis { get; set; }
    public byte? DispensaryObservation { get; set; }
    public string? ConcomitantDiagnosis { get; set; }
    public string? ComplicationDiagnosis { get; set; }
    public byte? AdditionalDispensaryObservation { get; set; }
    public string? MedicalEconomicStandardCode { get; set; }
    public string? ConcomitantMesCode { get; set; }
    public byte? IsRehabilitation { get; set; }
    public int PhysicianSpecialty { get; set; }
    public string MedicalSpecialtyCode { get; set; } = string.Empty;
    public string PhysicianCode { get; set; } = string.Empty;
    public decimal? PaidUnits { get; set; }
    public decimal? UnitRate { get; set; }
    public decimal ClaimedAmount { get; set; }
    public decimal? ApprovedAmount { get; set; }
    public decimal? InsuranceCompanyApprovedAmount { get; set; }
    public string? InternalComment { get; set; }
    public decimal? MedicalEconomicControlPenalty { get; set; }
    public decimal? MedicalEconomicExpertisePenalty { get; set; }
    public decimal? QualityMedicalCareExpertisePenalty { get; set; }
    public string? FacilityLevel { get; set; }
    public byte? IsOncologySuspicion { get; set; }
    public byte? DiseaseCharacter { get; set; }
    public decimal? Weight { get; set; }
    public byte? PreventiveCareMoCode { get; set; }
    public string? EncounterMoCode { get; set; }

    public CompletedCaseDbEntity CompletedCase { get; set; } = null!;
    public ClinicalGroupDbEntity ClinicalGroup { get; set; } = null!;
    public OncologyCaseDbEntity OncologyCase { get; set; } = null!;
    public List<ProvidedServiceDbEntity> ProvidedServices { get; set; } = [];
    public List<SanctionDbEntity> Sanctions { get; set; } = [];
    public List<ReferralDbEntity> Referrals { get; set; } = [];
    public List<PrescriptionDbEntity> Prescriptions { get; set; } = [];
    public List<ConsultationDbEntity> Consultations { get; set; } = [];
    public List<ConcomitantDiagnosisDbEntity> ConcomitantDiagnoses { get; set; } = [];
    public List<ComplicationDiagnosisDbEntity> ComplicationDiagnoses { get; set; } = [];
}