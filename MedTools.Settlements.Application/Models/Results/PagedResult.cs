namespace MedTools.Settlements.Application.Models.Results;

public sealed record PagedResult<T>(
    IReadOnlyCollection<T> Values,
    int TotalRecords);
