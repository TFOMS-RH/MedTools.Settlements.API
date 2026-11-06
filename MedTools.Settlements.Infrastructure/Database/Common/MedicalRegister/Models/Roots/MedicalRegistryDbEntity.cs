using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Headings;

namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Roots;

public sealed class MedicalRegistryDbEntity
{
    public int Uid { get; set; }

    public DateTime? UploadDate { get; set; }
    public string? Uploader { get; set; }
    public short Status { get; set; }

    public MedicalRegistryHeadingDbEntity MedicalRegistryHeading { get; set; } = null!;
    public InvoiceDbEntity Invoice { get; set; } = null!;
    public List<MedicalRecordDbEntity> MedicalRecords { get; set; } = [];
}