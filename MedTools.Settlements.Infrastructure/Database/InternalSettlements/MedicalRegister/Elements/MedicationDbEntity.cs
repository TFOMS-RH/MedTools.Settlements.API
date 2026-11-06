namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class MedicationDbEntity
{
    public int Uid { get; set; }
    public int OncologyServiceUid { get; set; }

    public string DrugIdentifier { get; set; } = string.Empty;
    public string? DrugExtendedIdentifier { get; set; }
    public string? TherapyRegimenCode { get; set; }

    public OncologyServiceDbEntity OncologyService { get; set; } = null!;
    public List<InjectionDateDbEntity> InjectionDates { get; set; } = [];
    public List<InjectionDbEntity> Injections { get; set; } = [];
}
