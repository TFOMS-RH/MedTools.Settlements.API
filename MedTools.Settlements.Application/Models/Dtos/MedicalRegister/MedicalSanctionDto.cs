namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record MedicalSanctionDto(
    int MedicalSanctionUid,
    string SanctionCode,
    decimal SanctionAmount,
    string ControlTypeCode,
    string? ControlTypeName,
    int RefusalReasonCode,
    string? RefusalReasonName,
    string? Comment,
    short Source,
    decimal UnitsRemoved,
    DateTime ExpertiseActDate,
    string ExpertiseActNumber,
    string? ExpertCode,
    string Filename,
    int? Year,
    int? Month,
    DateTime? UploadDate);
