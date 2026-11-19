using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Extractors;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.Extractions;

public static class ExtractUniqueBillingPeriodsCommand
{
    public static async Task<IResult> ExecuteAsync(
        string medicalOrganizationCode,
        MedicalRegisterType registerType,
        IMedicalRegisterExtractor extractor,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

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

        var billingPeriods = await extractor
            .ExtractBillingPeriodsAsync(
                medicalOrganizationCode,
                registerType,
                cancellationToken);

        return Results.Ok(billingPeriods);
    }
}
