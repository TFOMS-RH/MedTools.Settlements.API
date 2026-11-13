namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionPrescription(
    int PerscriptionUid,
    int SequenceNumber,
    byte PrescriptionTypeCode,
    string PrescriptionType,
    string? PhysicianSpecialtyCode,
    byte? DiagnosticMethodCode,
    string? DiagnosticMethod,
    string? ServiceCode,
    DateTime? ReferralDate,
    string? ReferredToMoCode,
    int? MedicalCareProfile,
    string? BedProfile);
