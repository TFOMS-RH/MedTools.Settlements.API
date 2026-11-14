using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyCases;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class OncologyCaseEndpoints
{
    public static RouteGroupBuilder MapOncologyCaseEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/oncology-cases")
            .WithTags("Oncology Cases");

        group.MapGet(
                pattern: "/{oncologyCaseUid:int}/diagnostics",
                handler: GetDiagnosticsByOncologyCaseUidCommand.ExecuteAsync)
            .WithName("GetDiagnosticsByOncologyCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{oncologyCaseUid:int}/contraindications",
                handler: GetContraindicationsByOncologyCaseUidCommand.ExecuteAsync)
            .WithName("GetContraindicationsByOncologyCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{oncologyCaseUid:int}/oncology-services",
                handler: GetOncologyServiceByOncologyCaseUidCommand.ExecuteAsync)
            .WithName("GetOncologyServiceByOncologyCaseUid")
            .WithDescription("");

        return builder;
    }
}
