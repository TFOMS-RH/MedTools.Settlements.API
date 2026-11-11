using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetMedicalCaseCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid < 0) return Results.BadRequest();

        var medicalCase = await medicalRegisterReader.GetMedicalCaseAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (medicalCase is null) return Results.NotFound();

        return Results.Ok(medicalCase);
    }
}
