using MedTools.Settlements.Web.Endpoints.Groups.MedicalRegisters.Sources;

namespace MedTools.Settlements.Web.Endpoints.Groups.MedicalRegisters;

public static class MedicalRegisterEndpoints
{
    public static RouteGroupBuilder MapMedicalRegisterEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder.MapGroup("/medical-register")
            .WithTags("Medical Registers");

        group.MapInvoiceEndpoints();

        return group;
    }
}
