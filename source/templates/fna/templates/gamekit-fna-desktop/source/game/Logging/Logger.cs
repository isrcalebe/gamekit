using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SampleGame.Game.Logging.Enrichers;
using Serilog;

namespace SampleGame.Game.Logging;

public static class Logger
{
    private static bool initialized;

    private static LoggerConfiguration baseConfiguration => new LoggerConfiguration()
        .Enrich.FromLogContext()
        .MinimumLevel.Debug()
        .WriteTo.Console(
            outputTemplate: "[{LoggingTarget:w}] {Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:w}]: {Message:lj}{NewLine}{Exception}"
        );

    private static Dictionary<LoggingTarget, ILogger> loggers = [];

    public static ILogger Information => getOrAdd(LoggingTarget.Information);

    public static ILogger Runtime => getOrAdd(LoggingTarget.Runtime);

    public static ILogger Network => getOrAdd(LoggingTarget.Network);

    public static ILogger Database => getOrAdd(LoggingTarget.Database);

    public static ILogger Input => getOrAdd(LoggingTarget.Input);

    public static void Setup()
    {
        if (initialized)
            return;

        initialized = true;

        Log.Logger = Information;

        FNALoggerEXT.LogInfo = Runtime.Information;
        FNALoggerEXT.LogWarn = Runtime.Warning;
        FNALoggerEXT.LogError = Runtime.Error;
    }

    private static ILogger getOrAdd(LoggingTarget target)
    {
        if (!loggers.TryGetValue(target, out var logger))
        {
            logger = baseConfiguration
                .Enrich.With(new LoggingTargetEnricher(target))
                .CreateLogger();
            loggers[target] = logger;
        }

        return logger;
    }
}
