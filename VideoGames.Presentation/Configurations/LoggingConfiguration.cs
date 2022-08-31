namespace VideoGames.Presentation.Configurations;

internal static class LoggingConfiguration
{
    public static void AddLoggingConfiguration(
        this IServiceCollection services,
        ConfigureHostBuilder hostBuilder)
    {
        hostBuilder.UseSerilog();

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override(source: "Microsoft", minimumLevel: LogEventLevel.Information)
            .WriteTo.File(path: "Logs/WebAppLog-.txt", rollingInterval: RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();

        services.AddHttpContextAccessor();
    }
}