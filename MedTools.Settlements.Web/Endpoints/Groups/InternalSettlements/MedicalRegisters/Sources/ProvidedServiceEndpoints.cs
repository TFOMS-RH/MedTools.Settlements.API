using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ProvidedServices;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class ProvidedServiceEndpoints
{
    public static RouteGroupBuilder MapProvidedServiceEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/provided-services")
            .WithTags("Provided Services");

        group.MapGet(
                pattern: "/{providedServiceUid}/medical-devices",
                handler: GetMedicalDevicesByProvidedServiceUidCommand.ExecuteAsync)
            .WithName("GetMedicalDevicesByProvidedServiceUid")
            .WithDescription("");

        return builder;
    }
}
