using MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.Extractions;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Extraction;

public static class MedicalRegisterExtractionEndpoints
{
    public static RouteGroupBuilder MapMedicalRegisterExtractionEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/extraction")
            .WithTags("Exctraction");

        group.MapGet(
                pattern: "/medical-organizations",
                handler: ExtractUniqueMedicalOrganizationsCommand.ExecuteAsync)
            .WithName("ExtractUniqueMedicalOrganizationCodes")
            .WithDescription("");

        group.MapGet(
                pattern: "/billing-periods",
                handler: ExtractUniqueBillingPeriodsCommand.ExecuteAsync)
            .WithName("ExtractUniqueBillingPeriods")
            .WithDescription("");

        return builder;
    }
}
