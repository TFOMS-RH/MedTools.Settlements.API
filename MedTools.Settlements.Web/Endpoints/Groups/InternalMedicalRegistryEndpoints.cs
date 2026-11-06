using MedTools.Settlements.Core.Enums;
using MedTools.Settlements.Application.Services;

namespace MedTools.Settlements.Web.Endpoints.Groups;

public static class InternalMedicalRegistryEndpoints
{
    public static IEndpointRouteBuilder RegisterInternalMedicalRegistryEndpoints(
        this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/medical-registers")
            .WithTags("Medical Registers");

        group.MapGet(
            "/invoices", 
            async (
                string medicalOrganizationCode,
                int year,
                int month,
                int page,
                int pageSize,
                string search,
                MedicalRegisterType medicalRegisterType,
                IMedicalRegisterReader reader,
                CancellationToken cancellationToken) =>
                {
                    var result = await reader.GetInvoicePagedResultAsync(
                        new Application.Models.Params.GetInvoiceParams(
                            MCode: medicalOrganizationCode,
                            BillingYear: year,
                            BillingMonth: month,
                            Page: page,
                            PageSize: pageSize,
                            Search: search,
                            RegisterType: medicalRegisterType),
                        cancellationToken: cancellationToken);

                    return Results.Ok(result);
                });

        return group;
    }
}
