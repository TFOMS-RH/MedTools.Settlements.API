using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyCases;

public static class GetContraindicationsByOncologyCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        IMedicalRegisterReader medicalRegisterReader,
        CancellationToken cancellationToken)
    {
        if (oncologyCaseUid < 0) return Results.BadRequest();

        var contraindications = await medicalRegisterReader.GetContraindicationsAsync(
            oncologyCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(contraindications);
    }
}
