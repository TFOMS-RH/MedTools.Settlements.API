namespace MedTools.Settlements.Web.DI;

public static class MedToolsSettlementsWebServiceCollectionExtensions
{
    public static IServiceCollection AddMedToolsSettlementsWebServices(
        this IServiceCollection services)
    {
        RegisterGlobalExceptionHandlers(services);

        return services;
    }

    private static void RegisterGlobalExceptionHandlers(
        IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandler>();
    }
}
