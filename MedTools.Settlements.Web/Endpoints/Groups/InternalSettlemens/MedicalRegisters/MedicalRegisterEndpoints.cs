using MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters.Sources;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlemens.MedicalRegisters;

public static class MedicalRegisterEndpoints
{
    public static RouteGroupBuilder MapMedicalRegisterEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-register")
            .WithTags("Medical Registers");

        group.MapMedicalInvoiceEndpoints();
        group.MapCompletedCaseEndpoints();

        return group;
    }
}
