using System;

namespace NASA.Framework.Logger {
    public interface ILogger {

        Guid ErrorLog(Exception ex, string message);
        Guid InfoLog(string logMessage);
        Guid WarningLog(string logMessage);
    }
}
