using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

public static class GetInjectionsByMedicationUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (medicationUid <= 0)
        {
            errors.AddError(
                "medicationUid",
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

        var injections = await reader
            .GetInjectionsAsync(
                medicationUid,
                registerType,
                cancellationToken);

        return Results.Ok(injections);
    }
}
