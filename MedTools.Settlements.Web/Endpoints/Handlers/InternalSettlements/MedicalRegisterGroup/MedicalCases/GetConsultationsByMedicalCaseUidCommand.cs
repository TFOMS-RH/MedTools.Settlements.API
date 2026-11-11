using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetConsultationsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        var consultations = await medicalRegisterReader.GetConsultationsAsync(
            medicalCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(consultations);
    }
}
