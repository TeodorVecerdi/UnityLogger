using UnityEngine;
using Object = UnityEngine.Object;

namespace Vecerdi.UnityLogger;

public static class Log {
    private static LogLevel? s_LogLevel;
    private static readonly List<ILogHandler> s_LogHandlers = new() { new UnityLogHandler() };

    public static LogLevel LogLevel {
        get => s_LogLevel ??= (LogLevel)PlayerPrefs.GetInt("Vecerdi.UnityLogger.LogLevel", (int)LogLevel.Debug);
        set => PlayerPrefs.SetInt("Vecerdi.UnityLogger.LogLevel", (int)(s_LogLevel = value));
    }

    public static void RegisterLogHandler(ILogHandler handler) {
        s_LogHandlers.Add(handler);
    }

    public static void UnregisterLogHandler(ILogHandler handler) {
        s_LogHandlers.Remove(handler);
    }

    public static void Trace(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Trace, /*logChannel, */context);
    }

    public static void Debug(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Debug, /*logChannel, */context);
    }

    public static void Info(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Info, /*logChannel, */context);
    }

    public static void Warn(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Warn, /*logChannel, */context);
    }

    public static void Error(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Error, /*logChannel, */context);
    }

    public static void Fatal(string? message, /*LogChannel logChannel, */Object? context = null) {
        Custom(message, LogLevel.Fatal, /*logChannel, */context);
    }

    public static void Exception(Exception? exception, /*LogChannel logChannel, */Object? context = null, LogLevel logLevel = LogLevel.Fatal) {
        if (exception == null || logLevel < LogLevel) return;

        foreach (ILogHandler logHandler in s_LogHandlers) {
            logHandler.HandleException(exception, /*logChannel, */ context, logLevel);
        }
    }

    public static void Custom(string? message, LogLevel logLevel, /*LogChannel logChannel, */Object? context = null) {
        if (logLevel < LogLevel) return;

        foreach (ILogHandler logHandler in s_LogHandlers) {
            logHandler.HandleLog(message, logLevel /*, logChannel*/, context);
        }
    }
}