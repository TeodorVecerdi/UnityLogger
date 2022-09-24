namespace Vecerdi.UnityLogger;

public interface ILogHandler {
    void HandleLog(string? message, LogLevel logLevel, /*LogChannel logChannel,*/ UnityEngine.Object? context = null);
    void HandleException(Exception exception, /*LogChannel logChannel,*/ UnityEngine.Object? context = null, LogLevel logLevel = LogLevel.Fatal);
}