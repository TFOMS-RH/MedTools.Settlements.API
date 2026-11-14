using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalInvoices;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

public static class MedicalInvoiceEndpoints
{
    public static RouteGroupBuilder MapMedicalInvoiceEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/medical-invoices")
            .WithTags("Medtical Invoices");


        group.MapGet(
                pattern: "/",
                handler: GetMedicalInvoicesCommand.ExecuteAsync)
            .WithName("GetMedicalInvoices")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalInvoiceUid:int}",
                handler: GetMedicalInvoiceDetailsCommand.ExecuteAsync)
            .WithName("GetMedicalInvoiceByUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalInvoiceUid:int}/completed-cases",
                handler: GetCompletedCasesByMedicalInvoiceUidCommand.ExecuteAsync)
            .WithName("GetCompletedCaseByMedicalInvoiceUid")
            .WithDescription("");

        return builder;
    }
}
