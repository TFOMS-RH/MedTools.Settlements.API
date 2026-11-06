namespace MedTools.Settlements.Web.Endpoints.Groups;

public static class InternalMedicalRegistryEndpoints
{
    public static IEndpointRouteBuilder RegisterInternalMedicalRegistryEndpoints(
        this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/medical-registers")
            .WithTags("Medical Registers");

        return group;
    }
}
