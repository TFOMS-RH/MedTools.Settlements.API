using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyServices;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class OncologyServiceEndpoints
{
    public static RouteGroupBuilder MapOncologyServiceEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/oncology-services")
            .WithTags("Oncology Services");

        group.MapGet(
                pattern: "/{oncologyServiceUid:int}/medications",
                handler: GetMedicationByOncologyServiceUidCommand.ExecuteAsync)
            .WithName("GetMedicationByOncologyServiceUid")
            .WithDescription("");

        return builder;
    }
}
