using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Web.Common.Extensions;

namespace MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

public static class GetOncologyCaseByMedicalCaseUidCommand
{
    public static async Task<IResult> ExecuteAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        IOncologyReader reader,
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

        if (errors.Count > 0)
        {
            return Results.ValidationProblem(errors);
        }

        var oncologyCase = await reader
            .GetOncologyCaseAsync(
                medicalCaseUid,
                registerType,
                cancellationToken);

        return Results.Ok(oncologyCase);
    }
}
