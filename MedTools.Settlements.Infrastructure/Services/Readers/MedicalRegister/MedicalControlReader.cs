using System.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public class MedicalControlReader(

    MedicalRegisterDbContextResolver dbContextResolver,
    IMapper mapper) : IMedicalControlReader
{
    public async Task<PagedResult<DefectDto>> GetDefectsAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var totalRecords = new SqlParameter(
            "@totalCount",
            SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        var result = await dbContext.Set<ProjectionDefect>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetDefects,
                parameters: [
                    new SqlParameter("@pMedicalCaseUid", medicalCaseUid),
                    new SqlParameter("@pSkip", pageSize * (page - 1)),
                    new SqlParameter("@pTake", pageSize),
                    totalRecords])
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return new PagedResult<DefectDto>(
            Values: mapper.Map<List<DefectDto>>(result),
            TotalRecords: totalRecords.Value is int total ? total : 0);

    }

    public async Task<IReadOnlyCollection<MedicalSanctionDto>> GetMedicalSanctionsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalSanction>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalSanctions,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicalSanctionDto>>(result);
    }
}
