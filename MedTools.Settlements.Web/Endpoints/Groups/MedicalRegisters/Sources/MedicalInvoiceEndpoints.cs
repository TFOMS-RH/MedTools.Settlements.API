using MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisterGroup.MedicalInvoices;

namespace MedTools.Settlements.Web.Endpoints.Groups.MedicalRegisters.Sources;

public static class MedicalInvoiceEndpoints
{
    public static RouteGroupBuilder MapInvoiceEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/medical-invoices")
            .WithTags("Medtical Invoices");

        group.MapGet("/", GetMedicalInvoicesCommand.ExecuteAsync);
        group.MapGet("/{medicalInvoiceUid:int}", GetMedicalInvoiceDetailsCommand.ExecuteAsync);

        return builder;
    }
}
