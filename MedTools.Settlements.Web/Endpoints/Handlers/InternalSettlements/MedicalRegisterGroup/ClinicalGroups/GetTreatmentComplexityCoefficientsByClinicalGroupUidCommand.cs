using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ClinicalGroups;

public static class GetTreatmentComplexityCoefficientsByClinicalGroupUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        if (clinicalGroupUid <= 0) return Results.BadRequest();

        var treatmentComplexityCoefficients = await reader.GetTreatmentComplexityCoefficientsAsync(
            clinicalGroupUid,
            registerType,
            cancellationToken);

        return Results.Ok(treatmentComplexityCoefficients);
    }
}
