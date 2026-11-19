using MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister;

public sealed record MedicalRegisterAppliedFilters(
    PersonFilters Person,
    MedicalCaseDetailsFilters MedicalCaseDetails,
    OncologyFilters Oncology,
    PrescriptionFilters Prescription,
    ClinicalGroupFilters ClinicalGroup,
    ProvidedServiceFilters ProvidedService,
    SanctionFilters Sanction,
    DiseaseFilters Diseases,
    InternalServiceFilters InternalService);
