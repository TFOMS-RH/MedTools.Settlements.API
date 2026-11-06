using Microsoft.EntityFrameworkCore;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;

namespace MedTools.Settlements.Infrastructure.Services.Readers;

public sealed class MedicalRegisterReader(
    MedToolsSettlementsDbContextFactory dbContextFactory) : IMedicalRegisterReader
{
    public async Task<PagedResult<InvoiceDto>> GetInvoicePagedResultAsync(
        GetInvoiceParams @params,
        CancellationToken cancellationToken)
    {
        await using var dbContext = dbContextFactory.CreateDbContext(@params.RegisterType);

        var baseQuery = dbContext.Set<InvoiceDbEntity>()
            .Where(x => x.MedicalOrganizationCode == @params.MCode
                && x.BillingMonth == @params.BillingMonth
                && x.BillingYear == @params.BillingYear);

        if (!string.IsNullOrWhiteSpace(@params.Search))
        {
            baseQuery = baseQuery.Where(
                x => x.InvoiceNumber.Contains(@params.Search));
        }

        var totalRecords = await baseQuery
            .CountAsync(cancellationToken);

        var items = await baseQuery
            .OrderBy(x => x.Uid)
            .Skip(@params.PageSize * (@params.Page - 1))
            .Take(@params.PageSize)
            .Select(x => new InvoiceDto(
                Uid: x.Uid,
                Number: x.InvoiceNumber,
                BillingDate: x.InvoiceBillingDate,
                Amount: x.InvoiceAmount,
                MedicalCasesCount: x.MedicalRegistry.MedicalRegistryHeading.TotalRecordCount ?? 0,
                Status: x.MedicalRegistry.Status))
            .ToListAsync(cancellationToken);

        return new PagedResult<InvoiceDto>(
            Values: items,
            TotalRecords: totalRecords);

    }
}