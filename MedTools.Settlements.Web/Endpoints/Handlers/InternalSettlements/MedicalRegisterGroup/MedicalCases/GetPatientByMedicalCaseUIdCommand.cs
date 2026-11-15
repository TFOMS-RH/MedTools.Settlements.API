using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetPatientByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IPatientReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid < 0) return Results.BadRequest();

        var patient = await reader.GetPatientAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (patient is null) return Results.NotFound();

        return Results.Ok(patient);
    }
}
