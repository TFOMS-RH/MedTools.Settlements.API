namespace MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

public sealed record ProjectionOncologyService(
    int OncologyServiceUid,
    byte ServiceTypeCode,
    string ServiceType,
    byte? SurgicalTreatmentTypeCode,
    string? SurgicalTreatmentType,
    byte? DrugTherapyLineCode,
    string? DrugTherapyLine,
    byte? DrugTherapyCycleCode,
    string? DrugTherapyCycle,
    bool? IsAntiemeticProphylaxis,
    byte? RadioTherapyTypeCode,
    string? RadiotherapyType);
