using MedTools.Settlements.Application.Models.Filters.MedicalRegister;

using MedTools.Settlements.Infrastructure.Common.Models;
using MedTools.Settlements.Infrastructure.Services.Extractors;

namespace MedTools.Settlements.Infrastructure.Services.Helpers;

public sealed class MedicalRegisterFilterResolver(
    ReferenceDataExtractor referenceDataExtractor)
{
    public async Task<ResolvedMedicalRegisterFilters> ResolveAsync(
        MedicalRegisterAppliedFilters appliedFilters,
        CancellationToken cancellationToken)
    {
        IReadOnlyCollection<int> stageKeys = [];
        IReadOnlyCollection<string> diseasesByClasses = [];
        IReadOnlyCollection<string> diseasesBySubClasses = [];

        if (appliedFilters.Oncology.OncologyCase.Stages.Count > 0)
        {
            stageKeys = await referenceDataExtractor
                .ExtractDiseaseStageKeysAsync(
                    appliedFilters.Oncology.OncologyCase.Stages,
                    cancellationToken);
        }

        if (appliedFilters.Diseases.BaseDisease.DiagnosisClasses.Count > 0)
        {
            diseasesByClasses = await referenceDataExtractor
                .ExtractDiseasesByDiseaseClassUidsAsync(
                    appliedFilters.Diseases.BaseDisease.DiagnosisClasses,
                    cancellationToken);
        }

        if (appliedFilters.Diseases.BaseDisease.DiagnosisSubClasses.Count > 0)
        {
            diseasesBySubClasses = await referenceDataExtractor
                .ExtractDiseasesByDiseaseSubClassUidsAsync(
                    appliedFilters.Diseases.BaseDisease.DiagnosisSubClasses,
                    cancellationToken);
        }

        return new ResolvedMedicalRegisterFilters
        {
            DiseaseStageKeys = stageKeys,
            DiseasesByClassUids = diseasesByClasses,
            DiseasesBySubClassUids = diseasesBySubClasses,
        };
    }
}
