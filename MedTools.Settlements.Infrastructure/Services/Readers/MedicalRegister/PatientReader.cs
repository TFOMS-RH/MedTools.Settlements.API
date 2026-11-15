using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Common.Exceptions;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public sealed class PatientReader(

    MedicalRegisterDbContextResolver dbContextResolver,
    IMapper mapper) : IPatientReader
{
    public async Task<PatientDto> GetPatientAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionPatient>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetPatient,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var patient = result.FirstOrDefault() ??
            throw new EntityNotFoundException(
                $"Не удалось найти пациента внутри мед. случая с UID {medicalCaseUid}");

        return mapper.Map<PatientDto>(patient);
    }

    public async Task<InsuranceDto> GetInsuranceAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionInsurance>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInsurance,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var insurance = result.FirstOrDefault() ??
            throw new EntityNotFoundException(
                $"Не удалось найти СМО внутри мед. случая с UID {medicalCaseUid}");

        return mapper.Map<InsuranceDto>(insurance);
    }
}
