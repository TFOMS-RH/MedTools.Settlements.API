namespace MedTools.Settlements.Infrastructure.Database.References.Models;

public sealed class DiseaseStageReferenceDbEntity
{
    public int Uid { get; set; }

    public int StageId { get; set; }
    public string? StageName { get; set; }
}
