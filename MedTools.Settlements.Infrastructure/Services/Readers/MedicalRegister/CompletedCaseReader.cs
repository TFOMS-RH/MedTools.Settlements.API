using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Common.Exceptions;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services.Helpers;
using MedTools.Settlements.Infrastructure.Services.Builders;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public sealed class CompletedCaseReader(
    MedicalRegisterDbContextResolver dbContextResolver,
    MedicalRegisterFilterResolver filterResolver,
    IMapper mapper) : ICompletedCaseReader
{
    public async Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        GetCompletedCasesByMedicalInvoiceUidParams @params,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(@params.RegisterType);

        var recordsCount = new SqlParameter(
            "@pTotalRecords",
            System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };

        var result = await dbContext.Set<ProjectionCompletedCase>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetCompletedCasesByMedicalInvoiceUid,
                parameters: [
                        new SqlParameter("@pMedicalInvoiceUid", @params.MedicalInvoiceUid),
                        new SqlParameter("@pSkip", @params.PageSize * (@params.Page - 1)),
                        new SqlParameter("@pTake", @params.PageSize),
                        new SqlParameter("@pSearch", @params.Search ?? ""),
                        recordsCount
                    ])
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return new PagedResult<CompletedCaseDto>(
            Values: mapper.Map<List<CompletedCaseDto>>(result),
            TotalRecords: recordsCount.Value is int total ? total : 0);

    }

    public async Task<PagedResult<CompletedCaseDto>> GetFilteredCompletedCasesAsync(
        GetFilteredCompletedCasesParams @params,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(
            @params.RegisterType);

        var resolvedFilterKeys = await filterResolver.ResolveAsync(
            @params.Filters,
            cancellationToken);

        var filterQuery = FilteredMedicalRegisterQueryBuilder.Build(
            @params.Filters,
            resolvedFilterKeys,
            dbContext);

        var totalRecords = await filterQuery.CountAsync(
            cancellationToken);

        var records = await filterQuery
            .OrderBy(x => x.CompletedCase.Uid)
            .Skip(@params.PageSize * (@params.Page - 1))
            .Take(@params.PageSize)
            .Select(x => new CompletedCaseDto(
                CompletedCaseUid: x.CompletedCase.Uid,
                MedicalOrganizationCode: x.CompletedCase.MedicalOrganizationCode,
                InsuranceOrganizationCode: x.CompletedCase.MedicalRecord.Patient.InsuranceCompanyCode,
                EntryNumber: x.CompletedCase.CaseRecordNumber,
                AmountBilled: x.CompletedCase.BilledAmount,
                ApprovedAmount: x.CompletedCase.ApprovedAmount,
                InsuranceCompanyApprovedAmount: x.CompletedCase.InsuranceCompanyApprovedAmount,
                MedicalCareConditionsCode: x.CompletedCase.CareCondition,
                MedicalCareConditionsName: null,
                PatientLastName: x.Person.PatientLastName,
                PatientFirstName: x.Person.PatientFirstName,
                PatientMiddleName: x.Person.PatientMiddleName,
                InsurancePolicySeries: x.CompletedCase.MedicalRecord.Patient.InsurancePolicySeries,
                InsurancePolicyNumber: x.CompletedCase.MedicalRecord.Patient.InsurancePolicyNumber,
                TreatmentStartDate: x.CompletedCase.TreatmentStartDate,
                TreatmentEndDate: x.CompletedCase.TreatmentEndDate,
                EntryPositionNumber: x.CompletedCase.MedicalRecord.RecordSequenceNumber))
            .ToListAsync(cancellationToken);

        return new PagedResult<CompletedCaseDto>(
            Values: records,
            TotalRecords: totalRecords);
    }

    public async Task<CompletedCaseDetailsDto> GetCompletedCaseAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionCompletedCaseDetails>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetCompletedCaseDetails,
                parameters: new SqlParameter("@pCompletedCaseUid", completedCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var completedCase = result.FirstOrDefault()
            ?? throw new EntityNotFoundException(
                $"Не удалось найти детали законченного случая с UID {completedCaseUid}");


        return mapper.Map<CompletedCaseDetailsDto>(completedCase);
    }

}