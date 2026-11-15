using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalInvoices;

public static class GetMedicalInvoiceDetailsCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalInvoiceUid,
        MedicalRegisterType registerType,
        IMedicalInvoiceReader reader,
        CancellationToken cancellationToken)
    {
        var medicalInvoiceDetails = await reader.GetMedicalInvoiceDetailsAsync(
            medicalInvoiceUid,
            registerType,
            cancellationToken);

        if (medicalInvoiceDetails is null) return Results.NotFound();

        return Results.Ok(medicalInvoiceDetails);
    }
}
