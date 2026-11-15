using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetProvidedServicesByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalServiceReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var providedServices = await reader.GetProvidedServicesAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(providedServices);
    }
}
