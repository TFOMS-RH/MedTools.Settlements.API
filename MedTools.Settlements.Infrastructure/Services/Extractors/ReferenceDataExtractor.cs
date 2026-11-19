using Microsoft.EntityFrameworkCore;

using MedTools.Settlements.Infrastructure.Database.References;
using MedTools.Settlements.Infrastructure.Database.References.Models;

namespace MedTools.Settlements.Infrastructure.Services.Extractors;

public sealed class ReferenceDataExtractor(
    ReferenceDataDbContext dbContext)
{
    public async Task<IReadOnlyCollection<int>> ExtractDiseaseStageKeysAsync(
        IReadOnlyCollection<string> labels,
        CancellationToken cancellationToken)
    {
        return await dbContext.Set<DiseaseStageReferenceDbEntity>()
            .Where(
                x => x.StageName != null &&
                labels.Contains(x.StageName))
            .Select(x => x.StageId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<string>> ExtractDiseasesByDiseaseClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken)
    {
        return await dbContext.Set<DiseaseReferenceDbEntity>()
            .Where(
                x => x.ClassCode.HasValue &&
                x.Code != null &&
                uids.Contains(x.ClassCode.Value))
            .AsNoTracking()
            .Select(x => x.Code!)
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<string>> ExtractDiseasesByDiseaseSubClassUidsAsync(
        IReadOnlyCollection<int> uids,
        CancellationToken cancellationToken)
    {
        return await dbContext.Set<DiseaseReferenceDbEntity>()
            .Where(
                x => x.SubClassCode.HasValue &&
                x.Code != null &&
                uids.Contains(x.SubClassCode.Value))
            .AsNoTracking()
            .Select(x => x.Code!)
            .ToListAsync(cancellationToken);
    } 
}
