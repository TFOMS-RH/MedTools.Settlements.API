using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Models.Results;

namespace MedTools.Settlements.Application.Models.Dtos;

public sealed class ImportFileContext<T>(
    string filename,
    ImportStatus importStatus,
    XmlFileValidationResult xmlFileValidationResult,
    XmlDeserializationResult<T>? xmlDeserializationResult)
{
    public string Filename { get; set; } = filename;
    public ImportStatus ImportStatus { get; set; } = importStatus;
    public XmlFileValidationResult XmlFileValidationResult { get; set; } = xmlFileValidationResult;
    public XmlDeserializationResult<T>? XmlDeserializationResult { get; set; } = xmlDeserializationResult;
}
