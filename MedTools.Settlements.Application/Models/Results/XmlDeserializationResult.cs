namespace MedTools.Settlements.Application.Models.Results;

public sealed record XmlDeserializationResult<T>(
    T? Value,
    ICollection<string> SchemaValidationErrors);
