namespace MedTools.Settlements.Infrastructure.Database.InternalSettlements.MedicalRegister.Elements;

public sealed class ComplicationDiagnosisDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public string DiagnosisName { get; set; } = string.Empty;

    public MedicalCaseDbEntity MedicalCase { get; set; } = new();
}
