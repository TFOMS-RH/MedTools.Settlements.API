using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.CompletedCases;

public static class GetMedicalCasesByCompletedCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (completedCaseUid < 0) return Results.BadRequest();

        var result = await medicalRegisterReader.GetMedicalCasesAsync(
            completedCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(result);
    }
}
