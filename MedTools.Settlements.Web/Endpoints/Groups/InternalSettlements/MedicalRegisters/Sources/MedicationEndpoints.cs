using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class MedicationEndpoints
{
    public static RouteGroupBuilder MapMedicationEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/medications")
            .WithTags("Medications");

        group.MapGet(
                pattern: "/{medicationUid}/injection-dates",
                handler: GetInjectionDatesByMedicationUidCommand.ExecuteAsync)
            .WithName("GetInjectionDatesByMedicationUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicationUid}/injections",
                handler: GetInjectionsByMedicationUidCommand.ExecuteAsync)
            .WithName("GetInjectionsByMedicationUid")
            .WithDescription("");

        return builder;
    }
}
