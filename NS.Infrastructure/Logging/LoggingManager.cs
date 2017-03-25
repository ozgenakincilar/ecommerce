using log4net;
using System;

namespace NS.Infrastructure.Logging
{
    public class LoggingManager : ILoggingManager
    {
        private static readonly ILog _infoLogger = LogManager.GetLogger("MyApplicationInfoLog");

        private static readonly ILog _errorLogger = LogManager.GetLogger("MyApplicationErrorLog");

        public void WriteErrorLog(Exception exception)
        {
            _errorLogger.Error(exception.Message, exception);
        }

        public void WriteLog(string message)
        {
            _infoLogger.InfoFormat(message);
        }
    }
}
