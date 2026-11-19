using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Application.Services.Extractors;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using MedTools.Settlements.Application.Services.Readers.MedicalRegister;

using MedTools.Settlements.Infrastructure.Services;
using MedTools.Settlements.Infrastructure.Common.Options;
using MedTools.Settlements.Infrastructure.Services.Extractors;
using MedTools.Settlements.Infrastructure.Services.Repositories;
using MedTools.Settlements.Infrastructure.Services.Readers.MedicalRegister;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.Contexts;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

using Incoming = MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming;
using Outgoing = MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Outgoing;

namespace MedTools.Settlements.Infrastructure.DI;

public static class MedToolsSettlementsInfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsSettlementsInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDatabaseOptions(services, configuration);
        RegisterDbContexts(services);
        RegisterMappers(services);
        RegisterRepositories(services);
        RegisterInternalServices(services);
        RegisterReaders(services);
        RegisterExtractors(services);

        return services;
    }

    private static void ConfigureDatabaseOptions(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<DatabaseOption>()
            .Bind(configuration.GetSection(DatabaseOption.SectionName))
            .Validate(
                x => !string.IsNullOrWhiteSpace(x.MTR.ConnectionString)
                && !string.IsNullOrWhiteSpace(x.SMODB18.ConnectionString)
                && !string.IsNullOrWhiteSpace(x.INOGOROD18.ConnectionString)
                && x.MTR.Timeout > 0
                && x.SMODB18.Timeout > 0
                && x.INOGOROD18.Timeout > 0)
            .ValidateOnStart();
    }

    private static void RegisterDbContexts(IServiceCollection services)
    {
        services.AddDbContext<InterterritorialSettlementDbContext>(
            (sp, dbContextOptionsBuilder) =>
            {
                var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOption>>().Value;

                dbContextOptionsBuilder.UseSqlServer(
                    connectionString: databaseOptions.MTR.ConnectionString,
                    (sqlServerOptionsBuilder) =>
                    {
                        sqlServerOptionsBuilder.CommandTimeout(databaseOptions.MTR.Timeout);
                    });
            });

        services.AddDbContext<InternalSettlementMedicalRegisterDbContext>(
            (sp, dbContextOptionsBuilder) =>
            {
                var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOption>>().Value;

                dbContextOptionsBuilder.UseSqlServer(
                    connectionString: databaseOptions.SMODB18.ConnectionString,
                    (sqlServerOptionsBuilder) =>
                    {
                        sqlServerOptionsBuilder.CommandTimeout(databaseOptions.SMODB18.Timeout);
                    });

            });

        services.AddDbContext<InterterritorialSettlementMedicalRegisterDbContext>(
            (sp, dbContextOptionsBuilder) =>
            {
                var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOption>>().Value;

                dbContextOptionsBuilder.UseSqlServer(
                    connectionString: databaseOptions.INOGOROD18.ConnectionString,
                    (sqlServerOptionsBuilder) =>
                    {
                        sqlServerOptionsBuilder.CommandTimeout(databaseOptions.INOGOROD18.Timeout);
                    });

            });
    }

    private static void RegisterReaders(IServiceCollection services)
    {
        services.AddScoped<ICompletedCaseReader, CompletedCaseReader>();
        services.AddScoped<IMedicalCareReader, MedicalCareReader>();
        services.AddScoped<IMedicalCaseReader, MedicalCaseReader>();
        services.AddScoped<IMedicalControlReader, MedicalControlReader>();
        services.AddScoped<IMedicalInvoiceReader, MedicalInvoiceReader>();
        services.AddScoped<IMedicalServiceReader, MedicalServiceReader>();
        services.AddScoped<IOncologyReader, OncologyReader>();
        services.AddScoped<IPatientReader, PatientReader>();
    }

    private static void RegisterExtractors(IServiceCollection services)
    {
        services.AddScoped<IMedicalRegisterExtractor, MedicalRegisterExtractor>();
    }

    private static void RegisterMappers(IServiceCollection services)
    {
        services.AddAutoMapper(config => { },
            typeof(Incoming.Mapping.ReconciliationActFileRootMappingProfile).Assembly,
            typeof(Outgoing.Mapping.ReconciliationActFileRootMappingProfile).Assembly);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<ReconciliationActRepository>();
    }

    private static void RegisterInternalServices(IServiceCollection services)
    {
        services.AddSingleton<XmlSchemaProvider>();
        services.AddSingleton<IXmlFileValidationService, XmlFileValidationService>();
        services.AddSingleton<IXmlDeserializationService<ReconciliationActFileRoot>, ReconciliationActXmlDeserializationService>();

        services.AddScoped<IActsImportService, ActsImportService>();
        services.AddScoped<MedicalRegisterDbContextResolver>();
    }
}
