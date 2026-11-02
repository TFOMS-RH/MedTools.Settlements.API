using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Infrastructure.Services;
using MedTools.Settlements.Infrastructure.Common.Options;
using MedTools.Settlements.Infrastructure.Database.Contexts;
using MedTools.Settlements.Infrastructure.Services.Repositories;

using XML = MedTools.Settlements.Application.Models.XML;
using Incoming = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Incoming;
using Outgoing = MedTools.Settlements.Infrastructure.Database.Interterritorial.Acts.Reconciliation.Outgoing;

namespace MedTools.Settlements.Infrastructure.DI;

public static class MedToolsSettlementInfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsInfrastructureSettlementsServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDatabaseOptions(services, configuration);
        RegisterDbContext(services);
        RegisterMappers(services);
        RegisterRepositories(services);
        RegisterValidators(services);
        RegisterProviders(services);
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

    private static void RegisterDbContext(IServiceCollection services)
    {
        services.AddDbContext<InterterritorialSettlementDbContext>((sp, dbContextOptionsBuilder) =>
        {
            var databaseOptions = sp.GetRequiredService<IOptions<DatabaseOption>>().Value;

            dbContextOptionsBuilder.UseSqlServer(
                connectionString: databaseOptions.MTR.ConnectionString,
                (sqlServerOptionsBuilder) =>
                {
                    sqlServerOptionsBuilder.CommandTimeout(databaseOptions.MTR.Timeout);
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

    private static void RegisterValidators(IServiceCollection services)
    {
        services.AddSingleton<IXmlValidationService<XML.ReconciliationAct.ReconciliationActFileRoot>, ReconciliationActXmlValidationService>();
    }

    private static void RegisterProviders(IServiceCollection services)
    {
        services.AddSingleton<XmlSchemaProvider>();
    }

    private static void RegisterInternalServices(IServiceCollection services)
    {
        services.AddScoped<IActsImportService, ActsImportService>();
    }
}
