using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Web.Common.Models.Request;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalInvoices;

public static class GetCompletedCasesByMedicalInvoiceUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalInvoiceUid,
        [AsParameters] GetCompletedCasesByMedicalInvoiceUidRequest request,
        ICompletedCaseReader reader,
        CancellationToken cancellationToken)
    {
        if (request.Page <= 0
            || request.PageSize <= 0
            || request.PageSize > 100) return Results.BadRequest();

        var result = await reader.GetCompletedCasesAsync(
            new GetCompletedCasesByMedicalInvoiceUidParams(
                MedicalInvoiceUid: medicalInvoiceUid,
                Page: request.Page,
                PageSize: request.PageSize,
                RegisterType: request.RegisterType,
                Search: request.Search),
            cancellationToken: cancellationToken);

        return Results.Ok(result);
    }
}
