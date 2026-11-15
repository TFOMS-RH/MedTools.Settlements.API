using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetOncologyCaseByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        var oncologyCase = await reader.GetOncologyCaseAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (oncologyCase is null) return Results.NotFound();

        return Results.Ok(oncologyCase);
    }
}
