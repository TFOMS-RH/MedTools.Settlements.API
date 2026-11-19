using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Web.Common.Constants;
using MedTools.Settlements.Web.Common.Extensions;
using MedTools.Settlements.Web.Common.Models.Request;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.Elements.CompletedCases;

public static class GetFilteredCompletedCasesCommand
{
    public static async Task<IResult> ExecuteAsync(
        GetFilteredCompletedCasesRequest request,
        ICompletedCaseReader completedCaseReader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (!Enum.IsDefined(request.RegisterType))
        {
            errors.AddError(
                field: "registerType",
                error: "Недопустимый тип медицинского реестраю.");
        }

        if (request.Page < PaginationConstants.MinPage)
        {
            errors.AddError(
                field: "page",
                error: $"Текушая страница должна быть больше {PaginationConstants.MinPage}.");
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

        var completedCases = await completedCaseReader.GetFilteredCompletedCasesAsync(
            new GetFilteredCompletedCasesParams(
                Filters: request.Filters,
                Page: request.Page,
                PageSize: request.PageSize,
                RegisterType: request.RegisterType),
            cancellationToken);

        return Results.Ok(completedCases);
    }
}