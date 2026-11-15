using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetInsuranceByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IPatientReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid < 0) return Results.BadRequest();

        var insurance = await reader.GetInsuranceAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (insurance is null) return Results.NotFound();

        return Results.Ok(insurance);
    }
}
