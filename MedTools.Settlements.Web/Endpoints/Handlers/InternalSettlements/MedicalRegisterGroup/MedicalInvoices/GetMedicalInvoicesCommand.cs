using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Constants;
using MedTools.Settlements.Web.Common.Extensions;
using MedTools.Settlements.Web.Common.Models.Request;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalInvoices;

public static class GetMedicalInvoicesCommand
{
    public static async Task<IResult> ExecuteAsync(
        [AsParameters] GetMedicalInvoicesRequest request,
        IMedicalInvoiceReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (!Enum.IsDefined(request.RegisterType))
        {
            errors.AddError(
                "registerType",
                "Недопустимый тип медицинского реестра.");
        }

        if (request.Page < PaginationConstants.MinPage)
        {
            errors.AddError(
                "page",
                "Текущая страница должна быть больше 0.");
        }

        if (request.PageSize < PaginationConstants.MinPageSize
            || request.PageSize > PaginationConstants.MaxPageSize)
        {
            errors.AddError(
                "pageSize",
                "Размер страницы должен быть в промежутке между 1 и 100.");
        }

        if (errors.Count > 0)
        {
            return Results.ValidationProblem(errors);
        }

        var medicalInvoicesPagedResult = await reader.GetMedicalInvoicesPagedResultAsync(
            new GetMedicalInvoiceParams(
                MCode: request.MedicalOrganizationCode,
                BillingYear: request.Year,
                BillingMonth: request.Month,
                Page: request.Page,
                PageSize: request.PageSize,
                Search: request.Search,
                RegisterType: request.RegisterType),
            cancellationToken: cancellationToken);

        return Results.Ok(medicalInvoicesPagedResult);
    }
}
