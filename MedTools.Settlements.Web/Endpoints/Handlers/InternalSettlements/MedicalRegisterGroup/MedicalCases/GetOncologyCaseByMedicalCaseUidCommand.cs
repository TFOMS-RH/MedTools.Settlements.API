using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetOncologyCaseByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        var oncologyCase = await medicalRegisterReader.GetOncologyCaseAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        if (oncologyCase is null) return Results.NotFound();

        return Results.Ok(oncologyCase);
    }
}
