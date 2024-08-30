using Services.Dao.Helpers;
using Services.Dao.Interfaces;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dao.Implementations.SQLServer
{
    public class LoggerDao : SqlTransactRepository
    {
        public LoggerDao(SqlConnection context, SqlTransaction _transaction) : base(typeof(Log), context, _transaction)
        {
        }
        private static string PathLogError { get; set; } = ConfigurationManager.AppSettings["PathLogError"];
        private static string PathLogInfo { get; set; } = ConfigurationManager.AppSettings["PathLogInfo"];

        public void WriteLog(Log log, Exception ex = null)
        {
            switch (log.TraceLevel)
            {

                case TraceLevel.Error:
                    string formatMessage = FormatMessage(log);
                    formatMessage += ex.StackTrace;

                    WriteToFile(PathLogError, formatMessage);
                    break;

                case TraceLevel.Warning:
                case TraceLevel.Verbose:
                case TraceLevel.Info:
                    //Aplicando particularidades para cada severidad...
                    WriteToFile(PathLogInfo, FormatMessage(log));
                    break;
            }
        }

        private string FormatMessage(Log log)
        {
            return $"{log.Date.ToString("dd/MM/yyyy HH:mm:ss")} [{log.TraceLevel}] : {log.Message}";
        }

        private void WriteToFile(string path, string message)
        {
            //Definir política de depuración de logs (Corte)
            path = DateTime.Now.ToString("dd-MM-yyyy") + path;

            using (StreamWriter str = new StreamWriter(path, true))
            {
                str.WriteLine(message);
            }
        }
    }
}
