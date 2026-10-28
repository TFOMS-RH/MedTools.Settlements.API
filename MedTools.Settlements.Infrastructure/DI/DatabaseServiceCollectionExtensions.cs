using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Infrastructure.Common.Options;
using MedTools.Settlements.Infrastructure.Database.Contexts;

namespace MedTools.Settlements.Infrastructure.DI;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsSettlementsDatabaseServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        ConfigureDatabaseOptions(services, configuration);
        RegisterDbContext(services);

        return services;
    }

    private static void ConfigureDatabaseOptions(
        IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<DatabaseOption>()
            .Bind(configuration.GetSection(DatabaseOption.SectionName))
            .Validate(x => x.MTR != null
                && !string.IsNullOrWhiteSpace(x.MTR.ConnectionString)
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
}
