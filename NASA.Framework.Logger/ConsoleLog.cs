using System;
using System.Collections.Generic;
using System.Text;

namespace NASA.Framework.Logger {
    public class ConsoleLog : ILogger {
        public ConsoleLog() {
        }

        public Guid ErrorLog(Exception ex, string message) {
            return Log($"{message}{System.Environment.NewLine}{ex.Message}", LogType.Error);//TODO:Inner Ex % StactTrace
        }

        public Guid InfoLog(string logMessage) {
            return Log(logMessage, LogType.Info);
        }

        public Guid WarningLog(string logMessage) {
            return Log(logMessage, LogType.Warning);
        }

        enum LogType {
            Warning,
            Info,
            Error
        }

        Guid Log(string message, LogType logType) {
            Guid logGuid = Guid.NewGuid();
            string logTypeDescription = "";
            if (logType == LogType.Warning) {
                logTypeDescription = "Warning";
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (logType == LogType.Info) {
                logTypeDescription = "Info";
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (logType == LogType.Error) {
                logTypeDescription = "Error";
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            if (message == null) message = "";
            
            Console.WriteLine($"--------------------------------------------------------------------");
            Console.WriteLine($"-- START LOG ----------");
            Console.WriteLine($"-- LOG MESSAGE: {message}");
            Console.WriteLine($"-- INSERT DATE: {DateTime.Now.ToString()}");
            Console.WriteLine($"-- LOG TYPE: {logTypeDescription}");
            Console.WriteLine($"-- END LOG   ----------");
            Console.WriteLine($"--------------------------------------------------------------------");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            return logGuid;
        }
    }
}
