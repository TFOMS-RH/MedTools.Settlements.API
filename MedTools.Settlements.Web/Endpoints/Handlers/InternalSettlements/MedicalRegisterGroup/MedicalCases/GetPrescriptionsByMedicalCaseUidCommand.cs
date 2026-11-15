using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetPrescriptionsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var prescriptions = await reader.GetPrescriptionsAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(prescriptions);
    }
}
