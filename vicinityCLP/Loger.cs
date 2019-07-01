/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
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
        private static string LogFolder = @"C:\VICINITY\Logs\";
        private static string pathEvents
        {
            get
            {
                return Path.Combine(LogFolder, "Events", DateTime.Today.ToString("yyyy-MM-dd") + ".log");
            }
        }

        private static string pathGTW
        {
            get
            {
                return Path.Combine(LogFolder, "Gateway", DateTime.Today.ToString("yyyy-MM-dd") + ".log");
            }
        }
        private static string pathAgent
        {
            get
            {
                return Path.Combine(LogFolder, "Agent", DateTime.Today.ToString("yyyy-MM-dd") + ".log");
            }
        }
        private static string pathAdapter
        {
            get
            {
                return Path.Combine(LogFolder, "Adapter", DateTime.Today.ToString("yyyy-MM-dd") + ".log");
            }
        }

        private static string AddTimeStamp()
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            while (text.Length < 30)
            {
                text += " ";
            }

            return text;
        }


        public static void Log(LogMsgType msg_type, string message, LogAuthor author)
        {
            string content = AddTimeStamp() + "[" + msg_type.ToString() + "]   " + message;
            
            try
            {
                if(author == LogAuthor.Agent)
                {
                    File.AppendAllText(pathAgent, Environment.NewLine + content);
                }
                else if(author == LogAuthor.GTW)
                {
                    File.AppendAllText(pathGTW, Environment.NewLine + content);
                }
                else if(author == LogAuthor.Event)
                {
                    File.AppendAllText(pathEvents, Environment.NewLine + content);
                }
                else if(author== LogAuthor.Adapter)
                {
                    File.AppendAllText(pathAdapter, Environment.NewLine + content);
                }
            }
            catch
            { }
        }
    }
}
