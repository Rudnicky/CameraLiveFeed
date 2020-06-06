using System;

namespace CameraLiveFeed.Core.Services.LoggerFactory
{
    public interface ILogger
    {
        void ProcessStarted(string methodName);
        void ProcessEnded(string methodName);
        void Info(string message);
        void Warning(string message);
        void Error(Exception exception);
        void Error(Exception exception, string message);
    }
}
