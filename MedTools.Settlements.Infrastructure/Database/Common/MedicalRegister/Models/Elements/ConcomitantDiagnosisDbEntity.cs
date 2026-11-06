namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

public sealed class ConcomitantDiagnosisDbEntity
{
    public int Uid { get; set; }
    public int MedicalCaseUid { get; set; }

    public string DiagnosisName { get; set; } = string.Empty;

    public MedicalCaseDbEntity MedicalCase { get; set; } = new();
}
