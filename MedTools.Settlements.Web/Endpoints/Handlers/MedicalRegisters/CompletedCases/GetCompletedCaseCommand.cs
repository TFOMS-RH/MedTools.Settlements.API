using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.MedicalRegisters.CompletedCases;

public static class GetCompletedCaseCommand
{
    public static async Task<IResult> ExecuteAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        ICompletedCaseReader reader,
        CancellationToken cancellationToken)
    {
        var errors = new Dictionary<string, string[]>();

        if (completedCaseUid <= 0)
        {
            errors.AddError(
                "completedCaseUid",
                "UID должен быть больше 0.");
        }

        if (!Enum.IsDefined(registerType))
        {
            errors.AddError(
                "registerType",
                "Недопустимый тип медицинского реестра.");
        }

        if (errors.Count > 0)
        {
            return Results.ValidationProblem(errors);
        }

        var completedCase = await reader
            .GetCompletedCaseAsync(
                completedCaseUid,
                registerType,
                cancellationToken);

        return Results.Ok(completedCase);
    }
}
