using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Headings;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

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