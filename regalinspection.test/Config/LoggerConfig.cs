using Serilog;

namespace regalinspection.test.Logging
{
    public static class LoggerConfig
    {
        public static void InitializeLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
