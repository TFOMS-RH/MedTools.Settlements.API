namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class InjectionDbEntity
{
    public int Uid { get; set; }
    public int MedicationUid { get; set; }

    public DateTime AdministrationDate { get; set; }
    public decimal? AdministeredQuantity { get; set; }
    public decimal? ConsumedQuantity { get; set; }
    public decimal? UnitCost { get; set; }
    public decimal? AdministeredCost { get; set; }
    public decimal? ConsumedCost { get; set; }
    public bool? IsReductionApplied { get; set; }

    public MedicationDbEntity Medication { get; set; } = null!;
 
}
