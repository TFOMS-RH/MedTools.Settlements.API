using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Extractors;

using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Services.Extractors;

public sealed class MedicalRegisterExtractor(
    IMapper mapper,
    MedicalRegisterDbContextResolver resolver) : IMedicalRegisterExtractor
{
    public async Task<IReadOnlyCollection<MedicalOrganizationDto>> ExtractMedicalOrganizationsAsync(
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = resolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalOrganization>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetExistingMedicalOrganizations)
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicalOrganizationDto>>(result);
    }

    public async Task<IReadOnlyCollection<BillingPeriodDto>> ExtractBillingPeriodsAsync(
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = resolver.GetDbContext(registerType);

        var flatPeriods = await dbContext.Set<MedicalInvoiceDbEntity>()
            .AsNoTracking()
            .Select(x => new
            {
                Year = x.BillingYear,
                Month = x.BillingMonth
            })
            .Distinct()
            .ToListAsync(cancellationToken: cancellationToken);

        var groupedPeriods = flatPeriods
            .GroupBy(period => period.Year)
            .Select(group => new BillingPeriodDto(
                BillingYear: group.Key,
                BillingMonths: [.. group
                    .Select(period => period.Month)
                    .OrderByDescending(x => x)]))
            .OrderBy(period => period.BillingYear)
            .ToList();

        return groupedPeriods;
    }
}
