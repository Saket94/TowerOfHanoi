using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TowerOfHanoi
{
    public class Logger
    {
        private string logFilePath = "";
        private static readonly object _fileAccessLock = new object();

        public Logger()
        {
            Init();
        }

        /// <summary>
        ///  Initiate logger, Set default dirctory and check for logfile.
        /// </summary>
        private void Init()
        {
            try
            {
                string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                logFilePath = Path.Combine(directory, @"ErrorLog.txt");
                if (!File.Exists(logFilePath))
                {
                    File.Create(logFilePath);
                }
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                }
            }
        }

        /// <summary>
        ///  Public method to be called from outside. This method Format the Log to write into the file.
        /// </summary>
        public bool CreateLog(string Msg, string Type, string Operation)
        {
            try
            {
                string logMessage = "";
                logMessage = "" + DateTime.Now.ToString("dd/MM/yyyy H:mm") + ",  " + Type + ", " + Operation + ", ";
                if (Type != "Error")
                    logMessage = logMessage + Msg;
                else
                    logMessage = logMessage + " Error Message : " + Msg;

                WriteToLog(logMessage, logFilePath);
                WriteToLog("----------------------------------------------------------------", logFilePath);
                return true;
            }
            catch (Exception ex)
            {
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                }
                return false;
            }
        }

        /// <summary>
        ///  Private method to write log into the file.
        /// </summary>
        private static void WriteToLog(string Message, string filepath)
        {
            lock (_fileAccessLock)
            {
                try
                {

                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        sw.WriteLine(Message);
                    }

                }
                catch (Exception ex)
                {
                    using (EventLog eventLog = new EventLog("Application"))
                    {
                        eventLog.Source = "Application";
                        eventLog.WriteEntry(ex.Message, EventLogEntryType.Information, 101, 1);
                    }
                }
            }
        }
    }
}
