namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record MedicalCaseDetailsFilters(
    BaseMedicalCaseDetailsFilters BaseMedicalCaseDetails,
    CompletedCaseDetailsFilters CompletedCaseDetails);

public sealed record BaseMedicalCaseDetailsFilters(
    string Division,
    string MedicalRecordNumber,
    DateTime? TreatmentEndDate,
    DateTime? TreatmentStartDate,
    List<int> MedicalProfiles,
    List<int> BedProfiles,
    List<int> PhysicianSpecialties,
    List<byte> DiseaseCharacters,
    List<byte> PreventiveCarePlaces,
    List<string> EncounterMedicalOrganizations,
    List<string> VisitPurposes);

public sealed record CompletedCaseDetailsFilters(
    DateTime? TreatmentEndDate,
    DateTime? TreatmentStartDate,
    List<int> CareConditions,
    List<byte> CareForms,
    List<int> DiseaseOutcomes,
    List<int> HospitalizationOutcomes,
    List<int> MedicalCareTypes,
    List<string> MedicalOrganizations,
    List<short> PaymentMethods,
    List<int> ScreeningResults,
    List<string> ReferringMedicalOrganizations);
