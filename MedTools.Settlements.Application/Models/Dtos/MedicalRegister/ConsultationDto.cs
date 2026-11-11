namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record ConsultationDto(
    int ConsultationUid,
    byte ConsultationPurposeCode,
    string ConsultationPurpose,
    DateTime? ConsultationDate);
