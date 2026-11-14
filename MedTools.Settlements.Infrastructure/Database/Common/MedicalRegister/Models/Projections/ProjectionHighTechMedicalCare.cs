namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionHighTechMedicalCare(
    string? HighTechCareTypeCode,
    string? HighTechCareTypeName,
    string? HighTechCareMethodCode,
    string? HighTechCareMethodName,
    DateTime? VoucherIssueDate,
    string? VoucherNumber,
    DateTime? PlannedAdmissionDate);
