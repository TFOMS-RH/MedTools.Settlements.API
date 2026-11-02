using MedTools.Settlements.Domain.Enums;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Dtos;
using MedTools.Settlements.Application.Imports.Dtos;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Application.Imports.Commands;

public sealed class ImportReconcilationActsCommand(
    IXmlValidationService<ReconciliationActFileRoot> xmlValidationService,
    IActsImportService actsImportService)
{
    public async Task<IReadOnlyCollection<XmlFileImportResult>> ExecuteCommandAsync(
        IReadOnlyCollection<ImportFile> requestFiles,
        Direction direction,
        CancellationToken cancellationToken)
    {
        if (requestFiles.Count == 0) throw new Exception();

        var importFileContexts = new List<ImportFileContext<ReconciliationActFileRoot>>();

        foreach (var requestFile in requestFiles)
        {
            var validationResult = xmlValidationService.Validate(
                fileStream: requestFile.Content,
                XmlFormat.S);

            var importFileContext = new ImportFileContext<ReconciliationActFileRoot>(
                filename: requestFile.Filename,
                importStatus: validationResult.Errors.Count == 0
                    && validationResult.Value is not null
                        ? ImportStatus.Validated
                        : ImportStatus.ValidationFailed,
                xmlValidationResult: validationResult);

            importFileContexts.Add(importFileContext);
        }

        var validatedFilesToSave = importFileContexts
            .Where(x => x.ImportStatus == ImportStatus.Validated
                && x.XmlValidationResult.Value != null)
            .Select(x => x.XmlValidationResult.Value!)
            .ToList();

        await actsImportService.ImportReconciliationActsAsync(
            validatedFilesToSave,
            direction,
            cancellationToken: cancellationToken);

        foreach (var fileContext in importFileContexts)
        {
            if (fileContext.ImportStatus == ImportStatus.Validated)
            {
                fileContext.ImportStatus = ImportStatus.Imported;
            }
        }

        return [.. importFileContexts.Select(
            x => new XmlFileImportResult(
                Filename: x.Filename,
                ImportStatus: x.ImportStatus,
                Errors: [.. x.XmlValidationResult.Errors]))];

    }
}