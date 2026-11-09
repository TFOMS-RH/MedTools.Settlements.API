using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;

using MedTools.Settlements.Application.Services;

using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.StoredProcedures;

namespace MedTools.Settlements.Infrastructure.Services.Readers;

public sealed class MedicalRegisterReader(
    MedToolsSettlementsDbContextFactory dbContextFactory,
    IMapper mapper) : IMedicalRegisterReader
{
    public async Task<PagedResult<MedicalInvoiceDto>> GetMedicalInvoicesPagedResultAsync(
        GetMedicalInvoiceParams @params,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(@params.RegisterType);

        var baseQuery = dbContext.Set<MedicalInvoiceDbEntity>()
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
            .Select(x => new MedicalInvoiceDto(
                Uid: x.Uid,
                Number: x.InvoiceNumber,
                BillingDate: x.InvoiceBillingDate,
                Amount: x.InvoiceAmount,
                MedicalCasesCount: x.MedicalRegistry.MedicalRegistryHeading.TotalRecordCount ?? 0,
                Status: x.MedicalRegistry.Status))
            .ToListAsync(cancellationToken);

        return new PagedResult<MedicalInvoiceDto>(
            Values: items,
            TotalRecords: totalRecords);

    }

    public async Task<MedicalInvoiceDetailsDto?> GetMedicalInvoiceDetailsAsync(
        int medicalInvoiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var medicalInvoiceDetailsList = await dbContext.Set<MedicalInvoiceDbEntity>()
            .AsNoTracking()
            .Where(x => x.Uid == medicalInvoiceUid)
            .Select(x => new MedicalInvoiceDetailsDto(
                InvoiceUid: x.Uid,
                Filename: x.MedicalRegistry.MedicalRegistryHeading.Filename,
                InvoiceUploadDate: x.MedicalRegistry.UploadDate,
                InvoiceAmount: x.InvoiceAmount,
                ApprovedAmount: x.ApprovedAmount,
                MedicalEconomicControlPenalty: x.MedicalEconomicControlPenalty,
                MedicalEconomicExpertisePenalty: x.MedicalEconomicExpertisePenalty,
                MedicalCareQualityExpertisePenalty: x.MedicalCareQualityExpertisePenalty,
                InsuranceCompanyApprovedAmount: x.InsuranceCompanyApprovedAmount,
                InsuranceCompanyMedicalEconomicControlPenalty: x.InsuranceCompanyMedicalEconomicControlPenalty,
                InsuranceCompanyMedicalEconomicExpertisePenalty: x.InsuranceCompanyMedicalEconomicExpertisePenalty,
                InsuranceCompanyMedicalCareQualityExpertisePenalty: x.InsuranceCompanyMedicalCareQualityExpertisePenalty))
            .ToListAsync(cancellationToken);

        return medicalInvoiceDetailsList.FirstOrDefault();
    }

    public async Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        GetCompletedCasesByMedicalInvoiceUidParams @params,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(@params.RegisterType);

        var recordsCount = new SqlParameter(
            "@total_count",
            System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var result = await dbContext.Set<ProjectionCompletedCase>()
            .FromSqlRaw(
                sql: StoredProcedureNames.GetCompletedCasesByMedicalInvoiceUid,
                parameters: [
                        new SqlParameter("@schet_uid", @params.MedicalInvoiceUid),
                        new SqlParameter("@skip", @params.PageSize * (@params.Page - 1)),
                        new SqlParameter("@take", @params.PageSize),
                        new SqlParameter("@search", @params.Search ?? ""),
                        recordsCount
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<CompletedCaseDto>(
            Values: mapper.Map<List<CompletedCaseDto>>(result),
            TotalRecords: recordsCount.Value is int total ? total : 0);

    }
}