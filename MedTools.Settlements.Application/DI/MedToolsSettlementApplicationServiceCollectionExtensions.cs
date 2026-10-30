using Microsoft.Extensions.DependencyInjection;

using MedTools.Settlements.Application.Imports.Commands;

namespace MedTools.Settlements.Application.DI;

public static class MedToolsSettlementApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsSettlementApplicationServices(
        this IServiceCollection services)
    {
        RegisterCommands(services);

        return services;
    }

    private static void RegisterCommands(
        IServiceCollection services)
    {
        services.AddScoped<ImportOutgoingReconcilationReportsCommand>();
    }
}
