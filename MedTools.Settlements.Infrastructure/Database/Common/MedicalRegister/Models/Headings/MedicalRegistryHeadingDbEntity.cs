using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Roots;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

public sealed class MedicalRegistryHeadingDbEntity
{
    public int MedicalRegistryUid { get; set; }

    public string? Version { get; set; }
    public DateTime? Date { get; set; }
    public string? Filename { get; set; }
    public int? TotalRecordCount { get; set; }

    public MedicalRegistryDbEntity MedicalRegistry { get; set; } = null!;
}
