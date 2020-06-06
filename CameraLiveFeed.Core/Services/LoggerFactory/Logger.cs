using System;

namespace CameraLiveFeed.Core.Services.LoggerFactory
{
    public class Logger : ILogger
    {
        private static readonly NLog.Logger NLogger = NLog.LogManager.GetCurrentClassLogger();

        public void ProcessStarted(string methodName)
        {
            NLogger.Info(methodName + " Processing Started.");
        }

        public void ProcessEnded(string methodName)
        {
            NLogger.Info(methodName + " Processing Ended.");
        }

        public void Info(string message)
        {
            NLogger.Info(message);
        }

        public void Warning(string message)
        {
            NLogger.Warn(message);
        }

        public void Error(Exception exception)
        {
            NLogger.Error(exception);
        }

        public void Error(Exception exception, string message)
        {
            NLogger.Error(exception, message);
        }
    }
}
