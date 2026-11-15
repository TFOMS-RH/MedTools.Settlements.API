using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.OncologyCases;

public static class GetDiagnosticsByOncologyCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
        CancellationToken cancellationToken)
    {
        if (oncologyCaseUid < 0) return Results.BadRequest();

        var diagnostics = await reader.GetDiagnosticsAsync(
            oncologyCaseUid,
            registerType,
            cancellationToken);

        return Results.Ok(diagnostics);
    }
}
