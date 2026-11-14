using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.Medications;

public static class GetInjectionsByMedicationUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (medicationUid < 0) return Results.BadRequest();

        var injections = await medicalRegisterReader.GetInjectionsAsync(
            medicationUid,
            registerType,
            cancellationToken);

        return Results.Ok(injections);
    }
}
