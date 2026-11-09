using MedTools.Settlements.Web.Endpoints.Groups.InterterritorialSettlements;
using MedTools.Settlements.Web.Endpoints.Groups.MedicalRegisters;

namespace MedTools.Settlements.Web.Endpoints.Groups;

public static class MedToolsSettlementEndpoints
{
    public static IEndpointRouteBuilder MapSettlementsEndpoints(
        this IEndpointRouteBuilder builder)
    {
        var group = builder
            .MapGroup("/api")
            .WithTags("MedTools Settlements API");

        group.MapMedicalRegisterEndpoints();
        group.MapInterterritorialSettlementEndpoints();

        return builder;
    }
}
