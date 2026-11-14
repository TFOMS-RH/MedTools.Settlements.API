using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Infrastructure.Services;
using MedTools.Settlements.Infrastructure.Common.Options;
using MedTools.Settlements.Infrastructure.Services.Readers;
using MedTools.Settlements.Infrastructure.Services.Factories;
using MedTools.Settlements.Infrastructure.Services.Repositories;
using MedTools.Settlements.Application.Models.XML.ReconciliationAct;
using MedTools.Settlements.Infrastructure.Database.InternalSettlements.Contexts;
using MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Contexts;

using Incoming = MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Incoming;
using Outgoing = MedTools.Settlements.Infrastructure.Database.InterterritorialSettlements.Acts.Reconciliation.Outgoing;

namespace MedTools.Settlements.Infrastructure.DI;

public static class MedToolsSettlementInfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsInfrastructureSettlementsServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDatabaseOptions(services, configuration);
        RegisterDbContexts(services);
        RegisterMappers(services);
        RegisterRepositories(services);
        RegisterInternalServices(services);

        return services;
    }

    private static void ConfigureDatabaseOptions(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<DatabaseOption>()
            .Bind(configuration.GetSection(DatabaseOption.SectionName))
            .Validate(x => !string.IsNullOrWhiteSpace(x.MTR.ConnectionString)
                && x.MTR.Timeout != 0)
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
        services.AddSingleton<IXmlDeserializationService<ReconciliationActFileRoot>, ReconciliationActXmlDeserializationService>();
        services.AddSingleton<XmlSchemaProvider>();
        services.AddSingleton<IXmlFileValidationService, XmlFileValidationService>();

        services.AddScoped<IMedicalRegisterReader, MedicalRegisterReader>();
        services.AddScoped<IActsImportService, ActsImportService>();
        services.AddScoped<MedToolsSettlementsDbContextFactory>();
    }
}
