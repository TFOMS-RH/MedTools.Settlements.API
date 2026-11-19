namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record OncologyFilters(
    OncologyCaseFilters OncologyCase,
    OncologyServiceFilters OncologyService,
    MedicationFilters Medication);

public sealed record OncologyCaseFilters(
    List<string> Stages,
    List<byte> ReferralReasons);

public sealed record OncologyServiceFilters(
    List<byte> DrugTherapyCycles,
    List<byte> RadioTherapyTypes,
    List<byte> ServiceTypes,
    List<byte> SurgicalTreatmentTypes,
    List<byte> DrugTherapyLines);

public sealed record MedicationFilters(
    List<string> DrugIdentifiers,
    List<string> TherapyRegimens);
