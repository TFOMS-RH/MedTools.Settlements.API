using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface IMedicalCareReader
{
    public Task<IReadOnlyCollection<PrescriptionDto>> GetPrescriptionsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<ReferralDto>> GetReferralsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<ClinicalGroupDto?> GetClinicalGroupAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<HighTechMedicalCareDto?> GetHighTechMedicalCareAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriteriaAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<TreatmentComplexityCoefficientDto>> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

}
