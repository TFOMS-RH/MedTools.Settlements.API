using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Roots;

public sealed class PersonRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short? Status { get; set; }

    public PersonRegistryHeadingDbEntity PersonRegistryHeading { get; set; } = null!;
    public List<PersonDbEntity> Persons { get; set; } = [];
}
