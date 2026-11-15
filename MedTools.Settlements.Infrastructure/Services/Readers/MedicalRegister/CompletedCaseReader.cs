using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;
using MedTools.Settlements.Application.Common.Exceptions;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public sealed class CompletedCaseReader(
    MedToolsSettlementsDbContextFactory dbContextFactory,
    IMapper mapper) : ICompletedCaseReader
{
    public async Task<PagedResult<CompletedCaseDto>> GetCompletedCasesAsync(
        GetCompletedCasesByMedicalInvoiceUidParams @params,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(@params.RegisterType);

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

    public async Task<CompletedCaseDetailsDto> GetCompletedCaseAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

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
