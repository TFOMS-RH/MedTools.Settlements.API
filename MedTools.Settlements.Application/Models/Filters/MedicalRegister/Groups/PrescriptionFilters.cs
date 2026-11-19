namespace MedTools.Settlements.Application.Models.Filters.MedicalRegister.Groups;

public sealed record PrescriptionFilters(
    BasePrescriptionFilters BasePrescription,
    ReferralFilters Referral);

public sealed record BasePrescriptionFilters(
    DateTime? ReferralDate,
    List<int> MedicalCareProfiles,
    List<byte> DiagnosticMethods,
    List<byte> PrescriptionTypes,
    List<string> ReferredToMedicalOrganizations,
    List<string> BedProfiles,
    List<string> Services);

public sealed record ReferralFilters(
    DateTime? ReferralDate,
    List<byte> DiagnosticMethods,
    List<byte> ReferralTypes,
    List<string> ReferredServices,
    List<string> ReferredToMedicalOrganizations);