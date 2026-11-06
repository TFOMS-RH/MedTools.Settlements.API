using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

namespace MedTools.Settlements.Application.Services;

public interface IMedicalRegisterReader
{
    public Task<PagedResult<InvoiceDto>> GetInvoicePagedResultAsync(
        GetInvoiceParams @params,
        CancellationToken cancellationToken);
}
