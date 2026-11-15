using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ClinicalGroups;

public static class GetTreatmentComplexityCoefficientsByClinicalGroupUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (clinicalGroupUid <= 0)
        {
            errors.AddError(
                "clinicalGroupUid",
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

        var treatmentComplexityCoefficients = await reader
            .GetTreatmentComplexityCoefficientsAsync(
                clinicalGroupUid,
                registerType,
                cancellationToken);

        return Results.Ok(treatmentComplexityCoefficients);
    }
}
