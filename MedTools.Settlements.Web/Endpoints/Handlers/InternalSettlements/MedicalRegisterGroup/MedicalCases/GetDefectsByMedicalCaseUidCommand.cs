using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetDefectsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        IMedicalControlReader reader,
        CancellationToken cancellationToken)
    {
        if (page < 0
            || pageSize < 0
            || pageSize > 100
            || medicalCaseUid <= 0) return Results.BadRequest();

        var defects = await reader.GetDefectsAsync(
            medicalCaseUid,
            page,
            pageSize,
            registerType,
            cancellationToken);

        return Results.Ok(defects);

    }
}
