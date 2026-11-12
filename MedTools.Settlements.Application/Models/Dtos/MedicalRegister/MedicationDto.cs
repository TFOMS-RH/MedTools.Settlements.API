namespace MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

public sealed record MedicationDto(
    int MedicamentUid,
    string DrugIdentifier,
    string? DrugExtendedIdentifier,
    string? TherapyRegimenCode);
