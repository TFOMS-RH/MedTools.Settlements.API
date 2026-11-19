namespace MedTools.Settlements.Infrastructure.Common.Models;

public sealed class ResolvedMedicalRegisterFilters
{
    public IReadOnlyCollection<int> DiseaseStageKeys { get; init; } = [];
    public IReadOnlyCollection<string> DiseasesByClassUids { get; init; } = [];
    public IReadOnlyCollection<string> DiseasesBySubClassUids { get; init; } = [];
}
