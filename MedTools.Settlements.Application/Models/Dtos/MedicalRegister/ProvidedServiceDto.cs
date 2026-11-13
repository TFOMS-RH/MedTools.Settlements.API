namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record ProvidedServiceDto(
    int ProvidedServiceUid,
    string ServiceCode,
    string? ServiceName,
    string? MedicalInterventionType,
    int MedicalProfileCode,
    string MedicalProfile,
    int PhysicianSpecialtyCode,
    string PhysicianSpecialty,
    bool IsPediatric,
    DateTime ServiceStartDate,
    DateTime ServiceEndDate,
    string DiagnosisCode,
    string? DiagnosisName,
    decimal ServiceQuantity,
    decimal? UnitRate,
    decimal AmountBilled,
    string? InternalComment);
