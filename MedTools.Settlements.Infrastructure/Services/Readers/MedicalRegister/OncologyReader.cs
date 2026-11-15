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

public sealed class OncologyReader(

    MedicalRegisterDbContextResolver dbContextResolver,
    IMapper mapper) : IOncologyReader
{
    public async Task<OncologyCaseDto> GetOncologyCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionOncologyCase>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetOncologyCase,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var oncologyCase = result.FirstOrDefault() ??
            throw new EntityNotFoundException(
                $"Не удалось найти онкологический случай внутри мед. случая с UID {medicalCaseUid}");

        return mapper.Map<OncologyCaseDto>(oncologyCase);
    }

    public async Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionConsultation>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetConsultations,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ConsultationDto>>(result);
    }

    public async Task<IReadOnlyCollection<DiagnosticDto>> GetDiagnosticsAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionDiagnostic>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetDiagnostics,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<DiagnosticDto>>(result);
    }

    public async Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionContraindication>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetContraindications,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ContraindicationDto>>(result);
    }

    public async Task<IReadOnlyCollection<OncologyServiceDto>> GetOncologyServicesAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionOncologyService>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetOncologyServices,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<OncologyServiceDto>>(result);
    }

    public async Task<IReadOnlyCollection<MedicationDto>> GetMedicationsAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedication>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedications,
                parameters: new SqlParameter("@pOncologyServiceUid", oncologyServiceUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicationDto>>(result);
    }

    public async Task<IReadOnlyCollection<InjectionDateDto>> GetInjectionDatesAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionInjectionDate>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInjectionDates,
                parameters: new SqlParameter("@pMedicationUid", medicationUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<InjectionDateDto>>(result);
    }

    public async Task<IReadOnlyCollection<InjectionDto>> GetInjectionsAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextResolver.GetDbContext(registerType);

        var result = await dbContext.Set<ProjectionInjection>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInjections,
                parameters: new SqlParameter("@pMedicationUid", medicationUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<InjectionDto>>(result);
    }
}
