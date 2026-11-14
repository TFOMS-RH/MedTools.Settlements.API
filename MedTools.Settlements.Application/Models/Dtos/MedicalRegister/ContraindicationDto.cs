namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record ContraindicationDto(
    int ContraindicationUid,
    byte ContraindicationCode,
    string Contraindication,
    DateTime ContraindicationDate);
