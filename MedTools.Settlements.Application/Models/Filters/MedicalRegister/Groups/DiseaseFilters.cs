namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record DiseaseFilters(
    AdditionalDiseaseFilters AdditionalDisease,
    BaseDiseaseFilters BaseDisease);

public sealed record AdditionalDiseaseFilters(
    List<string> InitialDiagnoses,
    List<string> ConcomitantDiagnoses,
    List<string> ComplicationDiagnoses);

public sealed record BaseDiseaseFilters(
    List<string> PrimaryDiagnoses,
    List<int> DiagnosisClasses,
    List<int> DiagnosisSubClasses);