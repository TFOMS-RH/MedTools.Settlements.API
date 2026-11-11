using System.Diagnostics.Contracts;

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
}
