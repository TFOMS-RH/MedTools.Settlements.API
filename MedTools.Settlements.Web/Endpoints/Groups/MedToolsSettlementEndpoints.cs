using MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters;
using MedTools.Settlements.Web.Endpoints.Groups.InterterritorialSettlements;

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
