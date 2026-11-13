namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;

public sealed class StoredProcedureSql
{
    public const string GetCompletedCasesByMedicalInvoiceUid = """
        EXEC mt_get_extended_completed_cases 
            @schet_uid, 
            @skip, 
            @take, 
            @search, 
            @total_count OUTPUT
        """;

    public const string GetMedicalCasesByCompletedCaseUid = """
        EXEC mt_get_extended_medical_cases 
            @pCompletedCaseUid
        """;

    public const string GetPatient = """
        EXEC mt_get_patient
            @pMedicalCaseUid
        """;

    public const string GetInsurance = """
        EXEC mt_rcontrol_get_insurance
            @pMedicalCaseUid
        """;

    public const string GetMedicalCaseDetails = """
        EXEC mt_rcontrol_get_medical_case_details
            @pMedicalCaseUid
        """;

    public const string GetCompletedCaseDetails = """
        EXEC mt_rcontrol_get_completed_case_details
            @pCompletedCaseUid
        """;

    public const string GetOncologyCase = """
        EXEC mt_rcontrol_get_oncology_case
            @pMedicalCaseUid
        """;

    public const string GetConsultations = """
        EXEC mt_rcontrol_get_consultations
            @pMedicalCaseUid
        """;

    public const string GetDiagnostics = """
        EXEC mt_rcontrol_get_diagnostics_records
            @pOncologyCaseUid
        """;

    public const string GetContraindications = """
        EXEC mt_rcontrol_get_contraindications
            @pOncologyCaseUid
        """;

    public const string GetOncologyServices = """
        EXEC mt_rcontrol_get_oncology_services
            @pOncologyCaseUid
        """;

    public const string GetMedications = """
        EXEC mt_rcontrol_get_medications
            @pOncologyServiceUid
        """;

    public const string GetInjectionDates = """
        EXEC mt_rcontrol_get_injection_dates
            @pMedicationUid
        """;

    public const string GetInjections = """
        EXEC mt_rcontrol_get_injections
            @pMedicationUid
        """;

    public const string GetPrescriptions = """
        EXEC mt_rcontrol_get_prescriptions
            @pMedicalCaseUid
        """;

    public const string GetReferrals = """
        EXEC mt_rcontrol_get_referrals
            @pMedicalCaseUid
        """;

    public const string GetClinicalGroup = """
        EXEC mt_rcontrol_get_clinical_group
            @pMedicalCaseUid
        """;

    public const string GetHighTechMedicalCare = """
        EXEC mt_rcontrol_get_high_tech_medical_care
            @pMedicalCaseUid
        """;

    public const string GetClassificationCriteria = """
        EXEC mt_rcontrol_get_classification_criteria
            @pClinicalGroupUid
        """;

    public const string GetTreatmentComplexityCoefficients = """
        EXEC mt_rcontrol_get_treatment_complexity_coefficients
            @pClinicalGroupUid
        """;

    public const string GetProvidedServices = """
        EXEC mt_rcontrol_get_provided_services
            @pMedicalCaseUid
        """;

    public const string GetMedicalDevices = """
        EXEC mt_rcontrol_get_medical_devices
            @pProvidedServiceUid
        """;

    public const string GetDefects = """
        EXEC mt_rcontrol_get_defects
            @pMedicalCaseUid,
            @pSkip,
            @pTake,
            @totalCount OUTPUT
        """;

    public const string GetMedicalSanctions = """
        EXEC mt_rcontrol_get_medical_sanctions
            @pMedicalCaseUid
        """;
}
