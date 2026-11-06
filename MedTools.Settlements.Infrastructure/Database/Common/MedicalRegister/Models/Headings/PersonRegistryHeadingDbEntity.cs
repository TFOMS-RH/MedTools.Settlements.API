using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Roots;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

public sealed class PersonRegistryHeadingDbEntity
{
    public int PersonRegistryUid { get; set; }

    public string? Version { get; set; }
    public DateTime? Date { get; set; }
    public string? PersonRegistryFilename { get; set; }
    public string? MedicalRegistryFilename { get; set; }

    public PersonRegistryDbEntity PersonRegistry { get; set; } = null!;
}
