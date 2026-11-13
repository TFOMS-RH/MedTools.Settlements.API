namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionProvidedService(
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
