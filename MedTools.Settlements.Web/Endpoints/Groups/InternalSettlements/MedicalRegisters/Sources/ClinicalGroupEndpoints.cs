using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ClinicalGroups;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class ClinicalGroupEndpoints
{
    public static RouteGroupBuilder MapClinicalGroupEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/clinical-groups")
            .WithTags("Clinical Groups");

        group.MapGet(
                pattern: "/{clinicalGroupUid:int}/classification-criteria",
                handler: GetClassificationCriteriaByClinicalGroupUidCommand.ExecuteAsync)
            .WithName("GetClassificationCriteriaByClinicalGroupUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{clinicalGroupUid:int}/treatment-complexity-coefficients",
                handler: GetTreatmentComplexityCoefficientsByClinicalGroupUidCommand.ExecuteAsync)
            .WithTags("GetTreatmentComplexityCoefficientsByClinicalGroupUid")
            .WithDescription("");

        return builder;
    }
}
