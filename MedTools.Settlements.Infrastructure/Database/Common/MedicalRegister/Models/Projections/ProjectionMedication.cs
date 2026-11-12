namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionMedication(
    int MedicamentUid,
    string DrugIdentifier,
    string? DrugExtendedIdentifier,
    string? TherapyRegimenCode);
