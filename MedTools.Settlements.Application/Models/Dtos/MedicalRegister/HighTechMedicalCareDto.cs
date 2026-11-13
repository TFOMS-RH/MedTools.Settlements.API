namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record HighTechMedicalCareDto(
    string? HighTechCareTypeCode,
    string? HighTechCareTypeName,
    string? HighTechCareMethodCode,
    string? HighTechCareMethodName,
    DateTime? VoucherIssueDate,
    string? VoucherNumber,
    DateTime? PlannedAdmissionDate);
