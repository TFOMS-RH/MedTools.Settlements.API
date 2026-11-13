
namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionTreatmentComplexityCoefficient(
    int TreatmentComplexityCoefficientUid,
    string? ComplexityCoefficientNumber,
    float ComplexityCoefficientValue);
