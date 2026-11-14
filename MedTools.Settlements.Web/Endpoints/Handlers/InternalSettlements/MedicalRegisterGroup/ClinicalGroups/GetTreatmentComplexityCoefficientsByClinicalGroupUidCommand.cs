using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ClinicalGroups;

public static class GetTreatmentComplexityCoefficientsByClinicalGroupUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (clinicalGroupUid <= 0) return Results.BadRequest();

        var treatmentComplexityCoefficients = await medicalRegisterReader.GetTreatmentComplexityCoefficientsAsync(
            clinicalGroupUid,
            registerType,
            cancellationToken);

        return Results.Ok(treatmentComplexityCoefficients);
    }
}
