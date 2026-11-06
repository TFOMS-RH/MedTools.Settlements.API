using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Headings;

public sealed class MedicalRegistryHeadingDbEntity
{
    public int MedicalRegistryUid { get; set; }

    public string? Version { get; set; }
    public DateTime? Date { get; set; }
    public string? Filename { get; set; }
    public int? TotalRecordCount { get; set; }

    public MedicalRegistryDbEntity MedicalRegistry { get; set; } = null!;
}
