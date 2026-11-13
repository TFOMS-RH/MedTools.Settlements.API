namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionMedicalDevice(
    int MedicalDeviceUid,
    DateTime ImplantationDate,
    int MedicalDeviceTypeCode,
    string SerialNumber);
