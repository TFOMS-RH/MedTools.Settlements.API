using MedTools.Settlements.Domain.Enums;
using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Imports.Dtos;

namespace MedTools.Settlements.Application.Imports.Commands;

public sealed class ImportOutgoingReconcilationReportsCommand(
    IXmlValidationService xmlValidationService)
{
    public async Task ExecuteCommandAsync(
        IReadOnlyCollection<ImportFile> files,
        CancellationToken cancellationToken)
    {
        var validationErrors = new Dictionary<string, List<string>>();

        foreach (var file in files)
        {
            var errors = xmlValidationService.Validate(
                file.Content, 
                XmlFormat.S);

            validationErrors.Add(
                file.FileName, 
                errors);
        }
    }
}