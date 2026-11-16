using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;
using MedTools.Settlements.Web.Common.Constants;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.MedicalCases;

public static class GetDefectsByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        IMedicalControlReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (medicalCaseUid <= 0)
        {
            errors.AddError(
                "medicalCaseUid",
                "UID должен быть больше 0.");
        }

        if (!Enum.IsDefined(registerType))
        {
            errors.AddError(
                "registerType",
                "Недопустимый тип медицинского реестра.");
        }

        if (page < PaginationConstants.MinPage)
        {
            errors.AddError(
                "page",
                "Текущая страница должна быть больше 0.");
        }

        if (pageSize < PaginationConstants.MinPageSize
            || pageSize > PaginationConstants.MaxPageSize)
        {
            errors.AddError(
                "pageSize",
                "Размер страницы должен быть в промежутке между 1 и 100.");
        }

        if (errors.Count > 0)
        {
            return Results.ValidationProblem(errors);
        }

        var defects = await reader
            .GetDefectsAsync(
                medicalCaseUid,
                page,
                pageSize,
                registerType,
                cancellationToken);

        return Results.Ok(defects);

    }
}
