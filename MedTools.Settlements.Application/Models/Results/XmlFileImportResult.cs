using MedTools.Settlements.Domain.Enums;

namespace MedTools.Settlements.Application.Models.Results;

public sealed record XmlFileImportResult(
    string Filename,
    ImportStatus ImportStatus,
    IReadOnlyCollection<string> Errors);
