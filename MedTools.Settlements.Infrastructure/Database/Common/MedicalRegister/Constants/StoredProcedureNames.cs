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
}
