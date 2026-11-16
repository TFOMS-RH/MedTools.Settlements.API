using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.MedicalInvoices;

public static class GetMedicalInvoiceDetailsCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalInvoiceUid,
        MedicalRegisterType registerType,
        IMedicalInvoiceReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (medicalInvoiceUid <= 0)
        {
            errors.AddError(
                "medicalCaseUid",
                "UID должен быть больше 0.");
        }

        if (!Enum.IsDefined(registerType))
        {
            errors.AddError(
                "registerType",
                "Недопустимый тип медицинского реестра.");
        }

        if (errors.Count > 0)
        {
            return Results.ValidationProblem(errors);
        }

        var medicalInvoiceDetails = await reader
            .GetMedicalInvoiceDetailsAsync(
                medicalInvoiceUid,
                registerType,
                cancellationToken);

        if (medicalInvoiceDetails is null) return Results.NotFound();

        return Results.Ok(medicalInvoiceDetails);
    }
}
