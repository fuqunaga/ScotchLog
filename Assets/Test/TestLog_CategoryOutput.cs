using NUnit.Framework;

namespace CategorizedLogging.Test.Editor
{
    public class TestLog_CategoryOutput
    {
        // -------------------------------------------------------
        // Log.Trace/Debug/Warning/Error() のカテゴリ名テスト（直接呼び出し）
        // -------------------------------------------------------

        [Test]
        public void LogTrace_Direct_EmitsCorrectCategory()
        {
            LogEntry? captured = null;
            using (Log.Listen(LogLevel.Trace, (in LogEntry e) => captured = e))
            {
                Log.Trace("trace message");
            }

            Assert.IsNotNull(captured);
            Assert.AreEqual(nameof(TestLog_CategoryOutput), captured!.Value.Category);
            Assert.AreEqual(LogLevel.Trace, captured!.Value.LogLevel);
        }

        [Test]
        public void LogDebug_Direct_EmitsCorrectCategory()
        {
            LogEntry? captured = null;
            using (Log.Listen(LogLevel.Debug, (in LogEntry e) => captured = e))
            {
                Log.Debug("debug message");
            }

            Assert.IsNotNull(captured);
            Assert.AreEqual(nameof(TestLog_CategoryOutput), captured!.Value.Category);
            Assert.AreEqual(LogLevel.Debug, captured!.Value.LogLevel);
        }

        [Test]
        public void LogWarning_Direct_EmitsCorrectCategory()
        {
            LogEntry? captured = null;
            using (Log.Listen(LogLevel.Warning, (in LogEntry e) => captured = e))
            {
                Log.Warning("warning message");
            }

            Assert.IsNotNull(captured);
            Assert.AreEqual(nameof(TestLog_CategoryOutput), captured!.Value.Category);
            Assert.AreEqual(LogLevel.Warning, captured!.Value.LogLevel);
        }

        [Test]
        public void LogError_Direct_EmitsCorrectCategory()
        {
            LogEntry? captured = null;
            using (Log.Listen(LogLevel.Error, (in LogEntry e) => captured = e))
            {
                Log.Error("error message");
            }

            Assert.IsNotNull(captured);
            Assert.AreEqual(nameof(TestLog_CategoryOutput), captured!.Value.Category);
            Assert.AreEqual(LogLevel.Error, captured!.Value.LogLevel);
        }
    }
}
