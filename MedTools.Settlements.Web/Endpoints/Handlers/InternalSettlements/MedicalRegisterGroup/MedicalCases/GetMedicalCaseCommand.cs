using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetMedicalCaseCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalCaseReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid < 0) return Results.BadRequest();

        var medicalCase = await reader.GetMedicalCaseAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (medicalCase is null) return Results.NotFound();

        return Results.Ok(medicalCase);
    }
}
