using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ClinicalGroups;

public static class GetClassificationCriteriaByClinicalGroupUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        if (clinicalGroupUid <= 0) return Results.BadRequest();

        var classificationCriteria = await reader.GetClassificationCriteriaAsync(
            clinicalGroupUid,
            registerType,
            cancellationToken);

        return Results.Ok(classificationCriteria);
    }
}
