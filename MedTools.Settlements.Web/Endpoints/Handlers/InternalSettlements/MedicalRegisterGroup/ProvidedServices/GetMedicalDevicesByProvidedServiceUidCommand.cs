using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ProvidedServices;

public static class GetMedicalDevicesByProvidedServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        IMedicalServiceReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (providedServiceUid <= 0)
        {
            errors.AddError(
                "providedServiceUid",
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

        var medicalDevices = await reader
            .GetMedicalDevicesAsync(
                providedServiceUid,
                registerType,
                cancellationToken);

        return Results.Ok(medicalDevices);
    }
}