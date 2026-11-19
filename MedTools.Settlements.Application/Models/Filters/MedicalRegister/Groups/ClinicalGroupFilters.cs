namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record ClinicalGroupFilters(
    BaseClinicalGroupFilters BaseClinicalGroup,
    HighTechMedicalCareFilters HighTechMedicalCare);

public sealed record BaseClinicalGroupFilters(
    List<string> ClinicalStatisticGroupNumbers,
    List<string> ComplexityCoefficientNumbers,
    List<string> InterruptedCasePaymentReasons);

public sealed record HighTechMedicalCareFilters(
    string VoucherNumber,
    DateTime? PlannedAdmissionDate,
    DateTime? VoucherIssueDate,
    List<string> HighTechCareMethods,
    List<string> HighTechCareTypes);
