using MedTools.Settlements.Web.Endpoints.Handlers.InterterritorialSettlements;

namespace MedTools.Settlements.Web.Endpoints.Groups;

public static class InterterritorialSettlementEndpoints
{
    public static IEndpointRouteBuilder RegisterInterterritorialSettlementEndpoints(
        this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/interterritorial-settlements")
            .WithTags("Interterritorial Settlements");

        group.MapPost("/outgoing-reconciliation-reports", ImportReconcilationActsHandler.HanldeAsync).DisableAntiforgery();

        group.MapPost("/incoming-reconciliation-reports", () => { });
        group.MapPost("/incoming-discrepancies", () => { });
        group.MapPost("/outgoing-discrepancies", () => { });

        return builder;
    }
}