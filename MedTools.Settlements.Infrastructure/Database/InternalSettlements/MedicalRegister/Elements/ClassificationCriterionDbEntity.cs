namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ClassificationCriterionDbEntity
{
    public int Uid { get; set; }
    public int ClinicalGroupUid { get; set; }

    public string? ClassificationCriterionName { get; set; }

    public ClinicalGroupDbEntity ClinicalGroup { get; set; } = null!;
}
