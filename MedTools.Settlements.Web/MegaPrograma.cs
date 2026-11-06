using System.Text;

using Microsoft.AspNetCore.Http.Features;

using Serilog;

using MedTools.Settlements.Application.DI;
using MedTools.Settlements.Infrastructure.DI;
using MedTools.Settlements.Web.Endpoints.Groups;

namespace MedTools.Settlements.Web;

public class MegaPrograma
{
    public static async Task Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(
                path: Path.Combine(
                    AppContext.BaseDirectory,
                    "logs/log.txt"),
                rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var builder = WebApplication.CreateBuilder();

        builder.Services.AddMedToolsSettlementApplicationServices();
        builder.Services.AddMedToolsInfrastructureSettlementsServices(builder.Configuration);
        builder.Services.Configure<FormOptions>(
            options =>
            {
                options.MultipartBodyLengthLimit = 50 * 1024 * 1024;
                options.ValueCountLimit = 100;
            });

        builder.Host.UseSerilog();

        builder.WebHost.ConfigureKestrel(
            config =>
            {
                config.ListenAnyIP(8010);
            });

        var app = builder.Build();

        app.UseRouting();

        app.MapGroup("/api").RegisterInterterritorialSettlementEndpoints();
        app.MapGroup("/api").RegisterInternalMedicalRegistryEndpoints();

        await app.RunAsync();
    }
}