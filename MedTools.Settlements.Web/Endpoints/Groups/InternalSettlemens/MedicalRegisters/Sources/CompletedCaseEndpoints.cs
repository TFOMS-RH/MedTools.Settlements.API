using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.CompletedCases;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters.Sources;

public static class CompletedCaseEndpoints
{
    public static RouteGroupBuilder MapCompletedCaseEndpoints(this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/completed-cases")
            .WithTags("Completed Cases");

        group.MapGet(
                pattern: "/{completedCaseUid:int}",
                handler: GetCompletedCaseCommand.ExecuteAsync)
            .WithName("GetCompletedCase")
            .WithDescription("");

        group.MapGet(
                pattern: "/{completedCaseUid:int}/medical-cases",
                handler: GetMedicalCasesByCompletedCaseUidCommand.ExecuteAsync)
            .WithName("GetMedicalCasesByCompletedCaseUid")
            .WithDescription("");

        return builder;
    }
}
