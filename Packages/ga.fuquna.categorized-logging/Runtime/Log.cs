using System;
using System.Runtime.CompilerServices;
using UnityEngine;

// ReSharper disable MemberCanBePrivate.Global
namespace CategorizedLogging
{
    /// <summary>
    /// CategorizedLogging インターフェース
    /// 
    /// カテゴリとして呼び出し元の型を使用する
    /// </summary>
    public static partial class Log
    {
        [field: ThreadStatic] private static LogPropertyHolder _propertyHolder;


        public static ILogDispatcher LogDispatcher { get; set; } = new LogDispatcher();
        [field: ThreadStatic] public static ILogDispatcher ThreadLocalDispatcher { get; set; }
        public static LogPropertyHolder PropertyHolder => _propertyHolder ??= new LogPropertyHolder();


        [HideInCallstack]
        private static void EmitLogInternal(in LogEntry logEntry)
        {
            LogDispatcher?.Log(in logEntry);
            ThreadLocalDispatcher?.Log(in logEntry);
        }

        [HideInCallstack]
        public static void EmitLog(in LogEntry logEntry)
        {
            if (PropertyHolder.HasContext)
            {
                var newEntry = new LogEntry(
                    logEntry.LogLevel,
                    $"{PropertyHolder.ToLogString()} {logEntry.Message}",
                    logEntry.CallerInfo
                );

                EmitLogInternal(in newEntry);
            }
            else
            {
                EmitLogInternal(in logEntry);
            }
        }

  
        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void EmitLog(LogLevel logLevel, string message, 
            [CallerFilePath] string callerFilePath = "", 
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
            )
        {
            EmitLog(new LogEntry(logLevel, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }


        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Trace(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Trace, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }

        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Debug(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Debug, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }
        
        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Information(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Information, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }

        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Warning(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Warning, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }

        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Error(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Error, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }

        [HideInCallstack]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Critical(string message,
            [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = 0,
            [CallerMemberName] string callerMemberName = ""
        )
        {
            EmitLog(new LogEntry(LogLevel.Critical, message,
                new CallerInformation(callerFilePath, callerLineNumber, callerMemberName)));
        }
    }
}