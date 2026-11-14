namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionReferral(
    int ReferralUid,
    DateTime ReferralDate,
    string? ReferredToMoCode,
    byte ReferralTypeCode,
    string ReferralType,
    byte? DiagnosticMethodCode,
    string? DiagnosticMethod,
    string? ReferredServiceCode,
    string? ReferredService);
