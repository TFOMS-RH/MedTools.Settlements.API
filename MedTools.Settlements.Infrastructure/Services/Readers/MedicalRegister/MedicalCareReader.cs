using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;
using MedTools.Settlements.Application.Common.Exceptions;

namespace MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;

public class MedicalCareReader(
     MedToolsSettlementsDbContextFactory dbContextFactory,
    IMapper mapper) : IMedicalCareReader
{
    public async Task<IReadOnlyCollection<PrescriptionDto>> GetPrescriptionsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionPrescription>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetPrescriptions,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<PrescriptionDto>>(result);
    }

    public async Task<IReadOnlyCollection<ReferralDto>> GetReferralsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionReferral>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetReferrals,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ReferralDto>>(result);
    }

    public async Task<ClinicalGroupDto> GetClinicalGroupAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionClinicalGroup>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetClinicalGroup,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var clinicalGroup = result.FirstOrDefault()
            ?? throw new EntityNotFoundException(
                $"Не удалось найти КСГ внутри мед. случая с UID {medicalCaseUid}");

        return mapper.Map<ClinicalGroupDto>(clinicalGroup);
    }

    public async Task<HighTechMedicalCareDto> GetHighTechMedicalCareAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionHighTechMedicalCare>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetHighTechMedicalCare,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var highTechMedicalCare = result.FirstOrDefault();

        return mapper.Map<HighTechMedicalCareDto>(highTechMedicalCare);
    }

    public async Task<IReadOnlyCollection<ClassificationCriterionDto>> GetClassificationCriteriaAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionClassificationCriterion>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetClassificationCriteria,
                parameters: new SqlParameter("@pClinicalGroupUid", clinicalGroupUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ClassificationCriterionDto>>(result);
    }

    public async Task<IReadOnlyCollection<TreatmentComplexityCoefficientDto>> GetTreatmentComplexityCoefficientsAsync(
        int clinicalGroupUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionTreatmentComplexityCoefficient>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetTreatmentComplexityCoefficients,
                parameters: new SqlParameter("@pClinicalGroupUid", clinicalGroupUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<TreatmentComplexityCoefficientDto>>(result);
    }
}
