using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.CompletedCases;

public static class GetCompletedCaseCommand
{
    public static async Task<IResult> ExecuteAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        ICompletedCaseReader reader,
        CancellationToken cancellationToken)
    {
        if (completedCaseUid < 0) return Results.BadRequest();

        var completedCase = await reader.GetCompletedCaseAsync(
            completedCaseUid,
            registerType,
            cancellationToken);

        if (completedCase is null) return Results.NotFound();

        return Results.Ok(completedCase);
    }
}
