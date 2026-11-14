namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record TreatmentComplexityCoefficientDto(
    int TreatmentComplexityCoefficientUid,
    string? ComplexityCoefficientNumber,
    float ComplexityCoefficientValue);