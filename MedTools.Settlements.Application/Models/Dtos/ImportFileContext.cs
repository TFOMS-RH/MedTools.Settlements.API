using MedTools.Settlements.Domain.Enums;
using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Application.Models.Dtos;

public sealed class ImportFileContext<T>(
    string filename,
    ImportStatus importStatus,
    XmlValidationResult<T> xmlValidationResult)
{
    public string Filename { get; set; } = filename;
    public ImportStatus ImportStatus { get; set; } = importStatus;
    public XmlValidationResult<T> XmlValidationResult { get; set; } = xmlValidationResult;
}
