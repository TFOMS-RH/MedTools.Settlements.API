namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionDiagnostic(
    int DiagnosticsUid,
    DateTime? SpecimenCollectionDate,
    byte? DiagnosticTypeCode,
    string? DiagnosticTypeName,
    int? DiagnosticCode,
    string? DiagnosticName,
    int? DiagnosticResultCode,
    string? DiagnosticResultName,
    bool? IsResultReceived);
