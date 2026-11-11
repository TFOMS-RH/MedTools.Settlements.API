using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters.Sources;

public static class MedicalCaseEndpoints
{
    public static RouteGroupBuilder MapMedicalCaseEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/medical-cases")
            .WithTags("Medical Cases");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}",
                handler: GetMedicalCaseCommand.ExecuteAsync)
            .WithName("GetMedicalCase")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/patient",
                handler: GetPatientByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetPatientByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/insurance",
                handler: GetInsuranceByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetInsuranceByMedicalCaseUid")
            .WithDescription("");

        return builder;
    }
}
