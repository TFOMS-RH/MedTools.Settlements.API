using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyCases;

public static class GetOncologyServiceByOncologyCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        if (oncologyCaseUid < 0) return Results.BadRequest();

        var oncologyServices = await reader.GetOncologyServicesAsync(
            oncologyCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(oncologyServices);
    }
}
