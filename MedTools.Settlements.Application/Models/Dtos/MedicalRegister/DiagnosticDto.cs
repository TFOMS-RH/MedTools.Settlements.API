namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record DiagnosticDto(
    int DiagnosticsUid,
    DateTime? SpecimenCollectionDate,
    byte? DiagnosticTypeCode,
    string? DiagnosticTypeName,
    int? DiagnosticCode,
    string? DiagnosticName,
    int? DiagnosticResultCode,
    string? DiagnosticResultName,
    bool? IsResultReceived);
