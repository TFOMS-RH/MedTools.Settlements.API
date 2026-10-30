using MedTools.Settlements.Domain.Enums;
using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Imports.Dtos;
using MedTools.Settlements.Application.Services.Repositories;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;

namespace MedTools.Settlements.Application.Imports.Commands;

public sealed class ImportOutgoingReconcilationReportsCommand(
    IXmlValidationService<ReconciliationActFileRoot> xmlValidationService,
    IReconciliationActRepository reconciliationActRepository)
{
    public async Task ExecuteCommandAsync(
        IReadOnlyCollection<ImportFile> files,
        CancellationToken cancellationToken)
    {

        var modelsToSave = new List<ReconciliationActFileRoot>();

        foreach (var file in files)
        {
            var result = xmlValidationService.Validate(
                file.Content,
                XmlFormat.S);

            if (result.Value is not null)
            {
                modelsToSave.Add(result.Value);
            }
        }

        await reconciliationActRepository.SaveAsync(
            modelsToSave, 
            cancellationToken);

    }
}