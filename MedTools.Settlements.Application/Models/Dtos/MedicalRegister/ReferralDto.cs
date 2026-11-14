namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record ReferralDto(
    int ReferralUid,
    DateTime ReferralDate,
    string? ReferredToMoCode,
    byte ReferralTypeCode,
    string ReferralType,
    byte? DiagnosticMethodCode,
    string? DiagnosticMethod,
    string? ReferredServiceCode,
    string? ReferredService);
