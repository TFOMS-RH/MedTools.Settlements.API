using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.ProvidedServices;

public static class GetMedicalDevicesByProvidedServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (providedServiceUid <= 0) return Results.BadRequest();

        var medicalDevices = await medicalRegisterReader.GetMedicalDevicesAsync(
            providedServiceUid,
            registerType,
            cancellationToken);

        return Results.Ok(medicalDevices);
    }
}
