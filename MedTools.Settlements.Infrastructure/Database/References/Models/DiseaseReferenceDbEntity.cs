namespace MedTools.Settlements.Infrastructure.Database.References.Models;

public sealed class DiseaseReferenceDbEntity
{
    public int? ClassCode { get; set; }
    public int? SubClassCode { get; set; }

    public string? Code { get; set; }
    public string? Name { get; set; }
}
