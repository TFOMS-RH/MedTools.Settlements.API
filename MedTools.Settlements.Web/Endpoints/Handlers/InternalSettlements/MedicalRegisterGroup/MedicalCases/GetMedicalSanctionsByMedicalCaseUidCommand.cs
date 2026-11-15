using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetMedicalSanctionsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalControlReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var medicalSanctions = await reader.GetMedicalSanctionsAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(medicalSanctions);
    }
}
