using MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Roots;

namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class MedicalRecordDbEntity
{
    public int Uid { get; set; }
    public int MedicalRegistryUid { get; set; }
    public int PatientUid { get; set; }

    public long RecordSequenceNumber { get; set; }
    public byte IsRevisedRecord { get; set; }

    public CompletedCaseDbEntity CompletedCase { get; set; } = null!;
    public MedicalRegistryDbEntity MedicalRegistry { get; set; } = null!;
    public PatientDbEntity Patient { get; set; } = null!;

}
