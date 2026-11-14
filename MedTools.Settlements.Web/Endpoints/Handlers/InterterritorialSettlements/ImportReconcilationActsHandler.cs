using MedTools.Settlements.Application.Imports.Dtos;
using MedTools.Settlements.Application.Imports.Commands;
using MedTools.Settlements.Core.Enums;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InterterritorialSettlements;

public static class ImportReconcilationActsHandler
{
    public static async Task<IResult> HanldeAsync(
        IFormFileCollection files,
        Direction direction,
        ImportReconciliationActsCommand command,
        CancellationToken cancellationToken)
    {
        if (files is null || files.Count == 0) return Results.BadRequest("Файлы не переданы.");

        var filesToImport = files.Select(
            requestFile => new ImportFile(
                Filename: requestFile.FileName,
                Length: requestFile.Length,
                Content: requestFile.OpenReadStream()))
            .ToList();

        try
        {
            var commandResult = await command.ExecuteCommandAsync(
                filesToImport,
                direction: direction,
                cancellationToken: cancellationToken);

            return Results.Ok(commandResult);
        }
        finally
        {
            foreach (var file in filesToImport) await file.Content.DisposeAsync();
        }
    }
}