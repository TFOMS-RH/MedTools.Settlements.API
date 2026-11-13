using MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters;

public static class MedicalRegisterEndpoints
{
    public static RouteGroupBuilder MapMedicalRegisterEndpoints(
        this RouteGroupBuilder builder)
    {
        var group = builder
            .MapGroup("/medical-register")
            .WithTags("Medical Registers");

        group.MapMedicalInvoiceEndpoints();
        group.MapCompletedCaseEndpoints();
        group.MapMedicalCaseEndpoints();
        group.MapOncologyCaseEndpoints();
        group.MapOncologyServiceEndpoints();
        group.MapMedicationEndpoints();
        group.MapClinicalGroupEndpoints();
        group.MapProvidedServiceEndpoints();

        return group;
    }
}
