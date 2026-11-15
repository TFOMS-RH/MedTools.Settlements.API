using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

public static class GetInjectionDatesByMedicationUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        if (medicationUid < 0) return Results.BadRequest();

        var injectionDates = await reader.GetInjectionDatesAsync(
            medicationUid,
            registerType,
            cancellationToken);

        return Results.Ok(injectionDates);
    }
}
