namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;

public sealed class StoredProcedureNames
{
    public const string GetCompletedCasesByMedicalInvoiceUid = """
        EXEC mt_get_extended_completed_cases 
            @schet_uid, 
            @skip, 
            @take, 
            @search, 
            @total_count OUTPUT
        """;
}
