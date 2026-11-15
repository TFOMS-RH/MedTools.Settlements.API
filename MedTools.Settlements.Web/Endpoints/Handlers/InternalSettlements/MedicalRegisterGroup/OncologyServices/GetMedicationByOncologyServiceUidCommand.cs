using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyServices;

public static class GetMedicationByOncologyServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        var medications = await reader.GetMedicationsAsync(
            oncologyServiceUid,
            registerType,
            cancellationToken);

        return Results.Ok(medications);
    }
}
