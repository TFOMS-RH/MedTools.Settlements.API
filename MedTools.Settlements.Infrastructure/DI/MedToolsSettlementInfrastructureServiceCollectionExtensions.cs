using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Application.Services;
using MedTools.Settlements.Infrastructure.Services;
using MedTools.Settlements.Infrastructure.Common.Options;
using MedTools.Settlements.Infrastructure.Database.Contexts;
using MedTools.Settlements.Application.Services.Repositories;
using MedTools.Settlements.Infrastructure.Services.Repositories;

using IncomingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.IncomingReconciliationAct;
using OutgoingReconciliationAct = MedTools.Settlements.Infrastructure.Database.Entities.Acts.OutgoingReconciliationAct;
using xmlReconciliationAct = MedTools.Settlements.Application.Models.XML.ReconciliationAct;


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
            typeof(IncomingReconciliationAct.Mapping.ReconciliationActFileRootMappingProfile).Assembly,
            typeof(OutgoingReconciliationAct.Mapping.ReconciliationActFileRootMappingProfile).Assembly);
    }

    private static void RegisterRepositories(IServiceCollection services)
    {
        services.AddScoped<IReconciliationActRepository, ReconciliationActRepository>();
    }

    private static void RegisterValidators(IServiceCollection services)
    {
        services.AddSingleton<IXmlValidationService<xmlReconciliationAct.ReconciliationActFileRoot>, ReconciliationActXmlValidationService>();
    }

    private static void RegisterProviders(IServiceCollection services)
    {
        services.AddSingleton<XmlSchemaProvider>();
    }
}
