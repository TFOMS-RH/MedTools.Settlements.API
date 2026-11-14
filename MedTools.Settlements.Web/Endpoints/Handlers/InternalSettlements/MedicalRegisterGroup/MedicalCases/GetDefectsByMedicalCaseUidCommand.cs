using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetDefectsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (page < 0
            || pageSize < 0
            || pageSize > 100
            || medicalCaseUid <= 0) return Results.BadRequest();

        var defects = await medicalRegisterReader.GetDefectsAsync(
            medicalCaseUid,
            page,
            pageSize,
            registerType,
            cancellationToken);

        return Results.Ok(defects);

    }
}
