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

    public Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
