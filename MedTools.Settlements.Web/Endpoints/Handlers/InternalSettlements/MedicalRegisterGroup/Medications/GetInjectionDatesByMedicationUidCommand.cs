using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

public static class GetInjectionDatesByMedicationUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (medicationUid < 0) return Results.BadRequest();

        var injectionDates = await medicalRegisterReader.GetInjectionDatesAsync(
            medicationUid,
            registerType,
            cancellationToken);

        return Results.Ok(injectionDates);
    }
}
