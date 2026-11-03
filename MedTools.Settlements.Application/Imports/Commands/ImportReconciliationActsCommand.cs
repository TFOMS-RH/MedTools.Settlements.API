using MedTools.Settlements.Domain.Enums;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Dtos;
using MedTools.Settlements.Application.Imports.Dtos;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Application.Imports.Commands;

public sealed class ImportReconciliationActsCommand(
    IXmlDeserializationService<ReconciliationActFileRoot> xmlDeserializationService,
    IXmlFileValidationService xmlFileValidationService,
    IActsImportService actsImportService)
{
    public async Task<IReadOnlyCollection<XmlFileImportResult>> ExecuteCommandAsync(
        IReadOnlyCollection<ImportFile> requestFiles,
        Direction direction,
        CancellationToken cancellationToken)
    {
        if (requestFiles.Count == 0) throw new Exception(); //TODO: Добавить доменные исключения
        if (requestFiles.Count > 100) throw new Exception(); //TODO: Добавить доменные исключения

        var importFileContexts = new List<ImportFileContext<ReconciliationActFileRoot>>();

        foreach (var requestFile in requestFiles)
        {
            var xmlFileValidationResult = xmlFileValidationService.Validate(
                filename: requestFile.Filename,
                fileStream: requestFile.Content);

            if (xmlFileValidationResult.IsValid)
            {
                var xmlDeserializationResult = xmlDeserializationService.Deserialize(
                    source: requestFile.Content,
                    XmlFormat.S);

                var deserializationContext = new ImportFileContext<ReconciliationActFileRoot>(
                    filename: requestFile.Filename,
                    importStatus: xmlDeserializationResult.SchemaValidationErrors.Count == 0
                        && xmlDeserializationResult.Value is not null
                            ? ImportStatus.Validated
                            : ImportStatus.SchemaValidationFailed,
                    xmlFileValidationResult: xmlFileValidationResult,
                    xmlDeserializationResult: xmlDeserializationResult);

                importFileContexts.Add(deserializationContext);

                continue;
            }

            var fileValidationContext = new ImportFileContext<ReconciliationActFileRoot>(
                filename: requestFile.Filename,
                importStatus: ImportStatus.FileValidationFailed,
                xmlFileValidationResult: xmlFileValidationResult,
                xmlDeserializationResult: null);

            importFileContexts.Add(fileValidationContext);
        }

        var validatedFilesToSave = importFileContexts
            .Where(x => x.ImportStatus == ImportStatus.Validated
                && x.XmlDeserializationResult != null
                && x.XmlDeserializationResult.Value != null)
            .Select(x => x.XmlDeserializationResult!.Value!)
            .ToList();

        if (validatedFilesToSave.Count > 0)
        {
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
        }

        return [.. importFileContexts.Select(
            x => new XmlFileImportResult(
                Filename: x.Filename,
                ImportStatus: x.ImportStatus,
                Errors: [.. x.XmlFileValidationResult.Errors
                    .Concat(x.XmlDeserializationResult?.SchemaValidationErrors ?? [])]))];

    }
}