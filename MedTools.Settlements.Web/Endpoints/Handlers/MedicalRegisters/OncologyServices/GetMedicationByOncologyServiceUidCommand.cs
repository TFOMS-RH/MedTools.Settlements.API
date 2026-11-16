using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.OncologyServices;

public static class GetMedicationByOncologyServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (oncologyServiceUid <= 0)
        {
            errors.AddError(
                "oncologyServiceUid",
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

        var medications = await reader
            .GetMedicationsAsync(
                oncologyServiceUid,
                registerType,
                cancellationToken);

        return Results.Ok(medications);
    }
}
