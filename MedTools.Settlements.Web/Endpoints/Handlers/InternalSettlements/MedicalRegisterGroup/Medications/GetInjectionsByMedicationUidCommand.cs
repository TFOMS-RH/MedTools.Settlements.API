using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

public static class GetInjectionsByMedicationUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        if (medicationUid < 0) return Results.BadRequest();

        var injections = await reader.GetInjectionsAsync(
            medicationUid,
            registerType,
            cancellationToken);

        return Results.Ok(injections);
    }
}
