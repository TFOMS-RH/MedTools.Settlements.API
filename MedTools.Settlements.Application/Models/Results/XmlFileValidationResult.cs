namespace MedTools.Settlements.Application.Models.Results;

public sealed record XmlFileValidationResult(
    bool IsValid,
    ICollection<string> Errors);
