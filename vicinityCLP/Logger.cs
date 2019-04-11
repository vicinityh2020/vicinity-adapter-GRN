using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vicinityCLP
{
    public enum LogMsgType { ERROR, INFO }
    public enum LogAuthor { GTW, Agent, Event, Adapter}

    public static class Logger
    {
        #region Properties

        #region Private
        private static string _logFolder = @"C:\VICINITY\Logs\";

        private static string _fileName
        {
            get
            {
                return DateTime.Today.ToString("yyyy-MM-dd") + ".log";
            }
        }

        private static string _pathEvents
        {
            get
            {
                return Path.Combine(_logFolder, "Events");
            }
        }

        private static string _pathGTW
        {
            get
            {
                return Path.Combine(_logFolder, "Gateway");
            }
        }

        private static string _pathAgent
        {
            get
            {
                return Path.Combine(_logFolder, "Agent");
            }
        }

        private static string _pathAdapter
        {
            get
            {
                return Path.Combine(_logFolder, "Adapter");
            }
        }
        #endregion

        #endregion

        #region Methods

        #region Private

        #region AddTimeStamp
        private static string AddTimeStamp()
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            while (text.Length < 30)
            {
                text += " ";
            }

            return text;
        }
        #endregion

        #endregion

        #region Public

        #region Log
        public static void Log(LogMsgType msg_type, string message, LogAuthor author)
        {
            string content = AddTimeStamp() + "[" + msg_type.ToString() + "]   " + message;
            
            try
            {
                switch (author)
                {
                    case LogAuthor.Agent:
                        {
                            if (!Directory.Exists(_pathAgent))
                            {
                                Directory.CreateDirectory(_pathAgent);
                            }
                            File.AppendAllText(Path.Combine(_pathAgent, _fileName), Environment.NewLine + content);
                            break;
                        }
                    case LogAuthor.GTW:
                        {
                            if (!Directory.Exists(_pathGTW))
                            {
                                Directory.CreateDirectory(_pathGTW);
                            }
                            File.AppendAllText(Path.Combine(_pathGTW, _fileName), Environment.NewLine + content);
                            break;
                        }
                    case LogAuthor.Event:
                        {
                            if (!Directory.Exists(_pathEvents))
                            {
                                Directory.CreateDirectory(_pathEvents);
                            }
                            File.AppendAllText(Path.Combine(_pathEvents, _fileName), Environment.NewLine + Environment.NewLine + content);
                            break;
                        }
                    case LogAuthor.Adapter:
                        {
                            if (!Directory.Exists(_pathAdapter))
                            {
                                Directory.CreateDirectory(_pathAdapter);
                            }
                            File.AppendAllText(Path.Combine(_pathAdapter, _fileName), Environment.NewLine + content);
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            catch
            { }
        }
        #endregion

        #endregion

        #endregion
    }
}
