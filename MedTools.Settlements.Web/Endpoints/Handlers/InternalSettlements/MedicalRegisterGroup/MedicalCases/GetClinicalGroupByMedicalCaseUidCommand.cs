using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetClinicalGroupByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (medicalCaseUid <= 0) return Results.BadRequest();

        var clinicalGroup = await medicalRegisterReader.GetClinicalGroupAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (clinicalGroup is null) return Results.NotFound();

        return Results.Ok(clinicalGroup);
    }
}
