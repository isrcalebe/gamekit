using System;
using Serilog.Core;
using Serilog.Events;

namespace SampleGame.Game.Logging.Enrichers;

/// <inheritdoc cref="ILogEventEnricher" />
public class LoggingTargetEnricher : ILogEventEnricher
{
    private readonly LoggingTarget target;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggingTargetEnricher"/> class.
    /// </summary>
    /// <param name="target">The logging target.</param>
    public LoggingTargetEnricher(LoggingTarget target)
    {
        this.target = target;
    }

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("LoggingTarget", getName(target)));
    }

    private string getName(LoggingTarget target)
        => target switch
        {
            LoggingTarget.Information => nameof(LoggingTarget.Information),
            LoggingTarget.Runtime => nameof(LoggingTarget.Runtime),
            LoggingTarget.Network => nameof(LoggingTarget.Network),
            LoggingTarget.Database => nameof(LoggingTarget.Database),
            LoggingTarget.Input => nameof(LoggingTarget.Input),
            _ => throw new ArgumentOutOfRangeException(nameof(target), target, null)
        };
}

public enum LoggingTarget
{
    Information,
    Runtime,
    Network,
    Database,
    Input
}
