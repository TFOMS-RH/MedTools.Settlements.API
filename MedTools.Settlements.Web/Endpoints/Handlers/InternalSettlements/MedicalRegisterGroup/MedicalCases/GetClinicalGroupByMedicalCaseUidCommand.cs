using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetClinicalGroupByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalCareReader reader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var clinicalGroup = await reader.GetClinicalGroupAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (clinicalGroup is null) return Results.NotFound();

        return Results.Ok(clinicalGroup);
    }
}
