namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record MedicalDeviceDto(
    int MedicalDeviceUid,
    DateTime ImplantationDate,
    int MedicalDeviceTypeCode,
    string SerialNumber);
