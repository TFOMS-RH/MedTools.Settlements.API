using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisterGroup.MedicalInvoices;

public static class GetMedicalInvoiceDetailsCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalInvoiceUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        var medicalInvoiceDetails = await medicalRegisterReader.GetMedicalInvoiceDetailsAsync(
            medicalInvoiceUid,
            registerType,
            cancellationToken);

        if (medicalInvoiceDetails is null) return Results.NotFound();

        return Results.Ok(medicalInvoiceDetails);
    }
}
