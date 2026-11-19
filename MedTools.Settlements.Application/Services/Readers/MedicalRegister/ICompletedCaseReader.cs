using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services.Readers.MedicalRegister;

public interface ICompletedCaseReader
{
    public Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        GetCompletedCasesByMedicalInvoiceUidParams @params,
        CancellationToken cancellationToken);

    public Task<PagedResult<CompletedCaseDto>> GetFilteredCompletedCasesAsync(
        GetFilteredCompletedCasesParams @params,
        CancellationToken cancellationToken);
         
    public Task<CompletedCaseDetailsDto> GetCompletedCaseAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken);
}
