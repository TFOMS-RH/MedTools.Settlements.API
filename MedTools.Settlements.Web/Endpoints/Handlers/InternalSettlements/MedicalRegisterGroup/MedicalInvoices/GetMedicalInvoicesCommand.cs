using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Web.Common.Models.Request;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalInvoices;

public static class GetMedicalInvoicesCommand
{
    public static async Task<IResult> ExecuteAsync(
        [AsParameters] GetMedicalInvoicesRequest request,
        IMedicalRegisterReader reader,
        CancellationToken cancellationToken)
    {
        if (request.Page <= 0 
            || request.PageSize <= 0 
            || request.PageSize > 100) return Results.BadRequest();

        var medicalInvoicesPagedResult = await reader.GetMedicalInvoicesPagedResultAsync(
            new GetMedicalInvoiceParams(
                MCode: request.MedicalOrganizationCode,
                BillingYear: request.Year,
                BillingMonth: request.Month,
                Page: request.Page,
                PageSize: request.PageSize,
                Search: request.Search,
                RegisterType: request.MedicalRegisterType),
            cancellationToken: cancellationToken);

        return Results.Ok(medicalInvoicesPagedResult);
    }
}
