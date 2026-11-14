using MedTools.Settlements.Web.Endpoints.Handlers.InternalSettlements.MedicalRegisterGroup.MedicalCases;

namespace MedTools.Settlements.Web.Endpoints.Groups.InternalSettlements.MedicalRegisters.Sources;

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

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/oncology-case",
                handler: GetOncologyCaseByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetOncologyCaseByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/consultations",
                handler: GetConsultationsByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetConsultationsByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/prescriptions",
                handler: GetPrescriptionsByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetPrescriptionsByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/referrals",
                handler: GetReferralsByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetReferralsByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/clinical-group",
                handler: GetClinicalGroupByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetClinicalGroupByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/high-tech-medical-care",
                handler: GetHighTechMedicalCareByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetHighTechMedicalCareByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/provided-services",
                handler: GetProvidedServicesByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetProvidedServicesByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/defects",
                handler: GetDefectsByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetDefectsByMedicalCaseUid")
            .WithDescription("");

        group.MapGet(
                pattern: "/{medicalCaseUid:int}/medical-sanctions",
                handler: GetMedicalSanctionsByMedicalCaseUidCommand.ExecuteAsync)
            .WithName("GetMedicalSanctionsByMedicalCaseUid")
            .WithDescription("");

        return builder;
    }
}
