using System.Data;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using AutoMapper;

using MedTools.Settlements.Core.Enums;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Models.Params;
using MedTools.Settlements.Application.Models.Results;
using MedTools.Settlements.Application.Models.Dtos.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Constants;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Elements;
using MedTools.Settlements.Infrastructure.Database.Common.MedicalRegister.Models.Projections;

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
            baseQuery = baseQuery
                .AsNoTracking()
                .Where(x => x.InvoiceNumber.Contains(@params.Search));
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

        var medicalInvoiceDetails = await dbContext.Set<MedicalInvoiceDbEntity>()
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
            .SingleOrDefaultAsync(cancellationToken);

        return medicalInvoiceDetails;
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
                sql: StoredProcedureSql.GetCompletedCasesByMedicalInvoiceUid,
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

    public async Task<CompletedCaseDetailsDto?> GetCompletedCaseAsync(
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

        var completedCase = result.FirstOrDefault();

        return completedCase is null
            ? null
            : mapper.Map<CompletedCaseDetailsDto>(completedCase);
    }

    public async Task<IReadOnlyCollection<MedicalCaseDto>> GetMedicalCasesAsync(
        int completedCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalCase>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalCasesByCompletedCaseUid,
                parameters: new SqlParameter("pCompletedCaseUid", completedCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return mapper.Map<List<MedicalCaseDto>>(result);

    }

    public async Task<MedicalCaseDetailsDto?> GetMedicalCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalCaseDetails>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalCaseDetails,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var medicalCase = result.FirstOrDefault();

        return medicalCase is null
            ? null
            : mapper.Map<MedicalCaseDetailsDto>(medicalCase);
    }

    public async Task<PatientDto?> GetPatientAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionPatient>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetPatient,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var patient = result.FirstOrDefault();

        return patient is null
            ? null
            : mapper.Map<PatientDto>(patient);
    }

    public async Task<InsuranceDto?> GetInsuranceAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionInsurance>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInsurance,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var insurance = result.FirstOrDefault();

        return insurance is null
            ? null
            : mapper.Map<InsuranceDto>(insurance);
    }

    public async Task<OncologyCaseDto?> GetOncologyCaseAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionOncologyCase>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetOncologyCase,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        var oncologyCase = result.FirstOrDefault();

        return oncologyCase is null
            ? null
            : mapper.Map<OncologyCaseDto>(oncologyCase);
    }

    public async Task<IReadOnlyCollection<ConsultationDto>> GetConsultationsAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

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
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionDiagnostic>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetDiagnostics,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<DiagnosticDto>>(result);
    }

    public async Task<IReadOnlyCollection<ContraindicationDto>> GetContraindicationsAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionContraindication>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetContraindications,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ContraindicationDto>>(result);
    }

    public async Task<IReadOnlyCollection<OncologyServiceDto>> GetOncologyServicesAsync(
        int oncologyCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionOncologyService>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetOncologyServices,
                parameters: new SqlParameter("@pOncologyCaseUid", oncologyCaseUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<OncologyServiceDto>>(result);
    }

    public async Task<IReadOnlyCollection<MedicationDto>> GetMedicationsAsync(
        int oncologyServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedication>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedications,
                parameters: new SqlParameter("@pOncologyServiceUid", oncologyServiceUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicationDto>>(result);
    }

    public async Task<IReadOnlyCollection<InjectionDateDto>> GetInjectionDatesAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionInjectionDate>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInjectionDates,
                parameters: new SqlParameter("@pMedicationUid", medicationUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<InjectionDateDto>>(result);
    }

    public async Task<IReadOnlyCollection<InjectionDto>> GetInjectionsAsync(
        int medicationUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionInjection>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetInjections,
                parameters: new SqlParameter("@pMedicationUid", medicationUid))
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<InjectionDto>>(result);
    }

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

    public async Task<ClinicalGroupDto?> GetClinicalGroupAsync(
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

        var clinicalGroup = result.FirstOrDefault();

        if (clinicalGroup is null) return null;

        return mapper.Map<ClinicalGroupDto>(clinicalGroup);
    }

    public async Task<HighTechMedicalCareDto?> GetHighTechMedicalCareAsync(
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

        if (highTechMedicalCare is null) return null;

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

    public async Task<IReadOnlyCollection<ProvidedServiceDto>> GetProvidedServicesAsync(
        int medicalCaseUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionProvidedService>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetProvidedServices,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<ProvidedServiceDto>>(result);
    }

    public async Task<IReadOnlyCollection<MedicalDeviceDto>> GetMedicalDevicesAsync(
        int providedServiceUid,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalDevice>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalDevices,
                parameters: new SqlParameter("@pProvidedServiceUid", providedServiceUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicalDeviceDto>>(result);
    }

    public async Task<PagedResult<DefectDto>> GetDefectsAsync(
        int medicalCaseUid,
        int page,
        int pageSize,
        MedicalRegisterType registerType,
        CancellationToken cancellationToken)
    {
        var dbContext = dbContextFactory.CreateDbContext(registerType);

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
        var dbContext = dbContextFactory.CreateDbContext(registerType);

        var result = await dbContext.Set<ProjectionMedicalSanction>()
            .FromSqlRaw(
                sql: StoredProcedureSql.GetMedicalSanctions,
                parameters: new SqlParameter("@pMedicalCaseUid", medicalCaseUid))
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);

        return mapper.Map<List<MedicalSanctionDto>>(result);
    }
}