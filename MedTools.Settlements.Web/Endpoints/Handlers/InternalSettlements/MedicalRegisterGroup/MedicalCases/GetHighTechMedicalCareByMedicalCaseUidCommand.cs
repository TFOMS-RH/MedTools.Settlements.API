using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetHighTechMedicalCareByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var highTechMedicalCare = await reader.GetHighTechMedicalCareAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (highTechMedicalCare is null) return Results.NotFound();

        return Results.Ok(highTechMedicalCare);
    }
}
