using System;
using System.IO;

namespace CategorizedLogging
{
    public readonly struct LogEntry
    {
        public DateTime Timestamp { get; }
        public LogLevel LogLevel { get; }
        public string Message { get; }
        public CallerInformation CallerInfo { get; }
        
        public string Category => Path.GetFileNameWithoutExtension(CallerInfo.FilePath);

        public LogEntry(LogLevel logLevel, string message, in CallerInformation callerInfoInformation)
        {
            Timestamp = DateTime.Now;
            LogLevel = logLevel;
            Message = message;
            CallerInfo = callerInfoInformation;
        }

        public override string ToString()
        {
            return $"[{Timestamp:yyyy-MM-dd HH:mm:ss.fff}][{LogLevel}][{Category}] {Message}";
        }
    }
}