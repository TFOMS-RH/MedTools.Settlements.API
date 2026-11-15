using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;
using MedTools.Settlements.Application.Common.Exceptions;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public class MedicalCaseReader(

    MedicalRegisterDbContextResolver dbContextResolver,
    IMapper mapper) : IMedicalCaseReader
{
    public async Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalCase>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalCasesByCompletedCaseUid,
                parameters: new SqlParameter("pCompletedCaseUid", completedCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return mapper.Map<List<MedicalCaseDto>>(result);

    }

    public async Task<MedicalCaseDetailsDto> GetMedicalCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalCaseDetails>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalCaseDetails,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var medicalCase = result.FirstOrDefault() ??
            throw new EntityNotFoundException(
                $"Не удалось получить мед. случай с UID {medicalCaseUid}");

        return mapper.Map<MedicalCaseDetailsDto>(medicalCase);
    }
}
