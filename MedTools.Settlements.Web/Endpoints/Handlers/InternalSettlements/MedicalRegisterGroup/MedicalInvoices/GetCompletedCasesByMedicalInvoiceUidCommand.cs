using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Constants;
using MedTools.Settlements.Web.Common.Extensions;
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
        var errors = new Dictionary<string, string[]>();

        if (medicalInvoiceUid <= 0)
        {
            errors.AddError(
                "medicalInvoiceUid",
                "UID должен быть больше 0.");
        }

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

        var completedCases = await reader.GetCompletedCasesAsync(
            new GetCompletedCasesByMedicalInvoiceUidParams(
                MedicalInvoiceUid: medicalInvoiceUid,
                Page: request.Page,
                PageSize: request.PageSize,
                RegisterType: request.RegisterType,
                Search: request.Search),
            cancellationToken: cancellationToken);

        return Results.Ok(completedCases);
    }
}
