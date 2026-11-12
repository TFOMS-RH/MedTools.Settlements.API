using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyCases;

public static class GetOncologyServiceByOncologyCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (oncologyCaseUid < 0) return Results.BadRequest();

        var oncologyServices = await medicalRegisterReader.GetOncologyServicesAsync(
            oncologyCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(oncologyServices);
    }
}
