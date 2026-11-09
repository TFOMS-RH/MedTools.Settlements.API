using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters.Sources;

public static class MedicalCaseEndpoints
{
    public static RouteGroupBuilder MapMedicalCaseEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-cases")
            .WithTags("Medical Cases");

        group.MapGet("/{medicalCaseUid:int}/patient", GetPatientByMedicalCaseUIdCommand.ExecuteAsync);

        return builder;
    }
}
