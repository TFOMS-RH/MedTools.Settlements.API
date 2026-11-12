using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services;

public interface IMedicalRegisterReader
{
    public Task<PagedResult<MedicalInvoiceDto>> GetMedicalInvoicesPagedResultAsync(
        GetMedicalInvoiceParams @params,
        CancellationToken cancellationToken);

    public Task<MedicalInvoiceDetailsDto?> GetMedicalInvoiceDetailsAsync(
        int medicalInvoiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        GetCompletedCasesByMedicalInvoiceUidParams @params,
        CancellationToken cancellationToken);

    public Task<CompletedCaseDetailsDto?> GetCompletedCaseAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<MedicalCaseDetailsDto?> GetMedicalCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<PatientDto?> GetPatientAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<InsuranceDto?> GetInsuranceAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<DiagnosticDto>> GetDiagnosticsAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<OncologyServiceDto>> GetOncologyServicesAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<MedicationDto>> GetMedicationsAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<InjectionDateDto>> GetInjectionDatesAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<InjectionDto>> GetInjectionsAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
