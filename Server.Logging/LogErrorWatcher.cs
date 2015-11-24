using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Logging
{
    public static class LogErrorWatcher
    {
        private static Logger fileLogger = LogManager.GetLogger("fileLogger");
        private static Logger databaseLogger = LogManager.GetLogger("databaseLogger");

        #region IErrorHandler Members

        public static void Error(string message, Exception exception, LogLevel logLevel)
        {
            try
            {
                databaseLogger.Log(logLevel, message, exception, DateTime.UtcNow);
            }
            catch (SqlException sqlEx)
            {
                GlobalDiagnosticsContext.Set("sqlExceptionStackTrace", sqlEx.StackTrace);
                fileLogger.Log(logLevel, message, exception, DateTime.UtcNow);
            }
        }

        public static void Error(string message, Exception exception)
        {
            try
            {
                databaseLogger.Log(LogLevel.Error, message, exception, DateTime.UtcNow);
                fileLogger.Log(LogLevel.Error, message, exception, DateTime.UtcNow);
            }
            catch (SqlException sqlEx)
            {
                GlobalDiagnosticsContext.Set("sqlExceptionStackTrace", sqlEx.StackTrace);
                fileLogger.Log(LogLevel.Error, message, exception, DateTime.UtcNow);
            }
        }

        public static void Error(string message)
        {
            try
            {
                databaseLogger.Log(LogLevel.Error, message, DateTime.UtcNow);
            }
            catch (SqlException sqlEx)
            {
                GlobalDiagnosticsContext.Set("sqlExceptionStackTrace", sqlEx.StackTrace);
                fileLogger.Log(LogLevel.Error, message, DateTime.UtcNow);
            }
        }

        public static void Error(string message, Exception exception, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                string json = JsonConvert.SerializeObject(args);
                GlobalDiagnosticsContext.Set("args", json);
            }
            
            Error(message, exception);
            
        }

        #endregion


        
    }
}
