using System.Text;
using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http.Features;

using Serilog;

using MedTools.Settlements.Web.DI;
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

        builder.Services
            .AddMedToolsSettlementsApplicationServices()
            .AddMedToolsSettlementsInfrastructureServices(builder.Configuration)
            .AddMedToolsSettlementsWebServices()
            .ConfigureHttpJsonOptions(
                options =>
                {
                    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
            .Configure<FormOptions>(
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
        app.UseExceptionHandler();
        app.MapSettlementsEndpoints();

        await app.RunAsync();
    }
}