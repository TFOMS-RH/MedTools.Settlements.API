namespace MedTools.Settlements.Application.Models.Results;

public sealed record XmlValidationResult<T>(
    T? Value,
    ICollection<string> Errors);
