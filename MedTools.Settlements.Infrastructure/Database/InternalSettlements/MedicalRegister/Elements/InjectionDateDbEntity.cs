namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class InjectionDateDbEntity
{
    public int Uid { get; set; }
    public int MedicationUid { get; set; }

    public DateTime InjectionDate { get; set; }

    public MedicationDbEntity Medication { get; set; } = null!;
}
