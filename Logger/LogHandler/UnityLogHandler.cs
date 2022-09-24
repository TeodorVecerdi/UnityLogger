using Object = UnityEngine.Object;

namespace Vecerdi.UnityLogger;

internal class UnityLogHandler : ILogHandler {
    public void HandleLog(string? message, LogLevel logLevel, /*LogChannel logChannel, */Object? context = null) {
        string logMessage = GetLogMessage(message, logLevel /*, logChannel*/);

        switch (logLevel) {
            case LogLevel.Trace: UnityEngine.Debug.Log(logMessage, context); break;
            case LogLevel.Debug: UnityEngine.Debug.Log(logMessage, context); break;
            case LogLevel.Info: UnityEngine.Debug.Log(logMessage, context); break;
            case LogLevel.Warn: UnityEngine.Debug.LogWarning(logMessage, context); break;
            case LogLevel.Error: UnityEngine.Debug.LogError(logMessage, context); break;
            case LogLevel.Fatal: UnityEngine.Debug.LogError(logMessage, context); break;
            default: throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
        }
    }

    public void HandleException(Exception exception, /*LogChannel logChannel, */Object? context = null, LogLevel logLevel = LogLevel.Fatal) {
        UnityEngine.Debug.LogException(exception, context/*, logChannel*/);
    }

    private static string GetLogMessage(string? message, LogLevel logLevel /*, LogChannel logChannel*/) {
        // TODO: Implement log channel and proper message formatting
        return $"[{logLevel}] {message}";
    }
}