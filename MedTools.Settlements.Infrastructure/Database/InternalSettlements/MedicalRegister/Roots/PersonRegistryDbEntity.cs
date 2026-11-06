using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Headings;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

public sealed class PersonRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short? Status { get; set; }

    public PersonRegistryHeadingDbEntity PersonRegistryHeading { get; set; } = null!;
    public List<PersonDbEntity> Persons { get; set; } = [];
}
