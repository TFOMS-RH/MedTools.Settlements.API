using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ProvidedServices;

public static class GetMedicalDevicesByProvidedServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        IMedicalServiceReader reader,
        CancellationToken cancellationToken)
    {
        if (providedServiceUid <= 0) return Results.BadRequest();

        var medicalDevices = await reader.GetMedicalDevicesAsync(
            providedServiceUid,
            registerType,
            cancellationToken);

        return Results.Ok(medicalDevices);
    }
}
