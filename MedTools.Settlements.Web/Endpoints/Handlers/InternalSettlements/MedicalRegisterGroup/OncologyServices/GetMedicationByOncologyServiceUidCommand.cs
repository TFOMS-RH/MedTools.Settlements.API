using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyServices;

public static class GetMedicationByOncologyServiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        var medications = await medicalRegisterReader.GetMedicationsAsync(
            oncologyServiceUid,
            registerType,
            cancellationToken);

        return Results.Ok(medications);
    }
}
