using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetMedicalSanctionsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var medicalSanctions = await medicalRegisterReader.GetMedicalSanctionsAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(medicalSanctions);
    }
}
