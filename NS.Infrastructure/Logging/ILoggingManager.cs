using System;

namespace NS.Infrastructure.Logging
{
    public interface ILoggingManager
    {
        void WriteLog(string message);
        void WriteErrorLog(Exception exception);
    }
}
