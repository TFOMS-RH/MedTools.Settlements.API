using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.CompletedCases;

public static class GetMedicalCasesByCompletedCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        IMedicalCaseReader reader,
        CancellationToken cancellationToken)
    {
        if (completedCaseUid < 0) return Results.BadRequest();

        var result = await reader.GetMedicalCasesAsync(
            completedCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(result);
    }
}
