using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vicinityCLP;

namespace VicinityCLP.Service
{
    public class Client
    {
        #region Properties

        #region Private
        private Process process_gateway;
        private Process process_agent;
        private ServiceWorker worker;
        #endregion

        #endregion

        #region Methods

        #region Public

        #region Start
        public void Start()
        {
            process_gateway = null;
            process_agent = null;

            string result = runCMD(@"netstat -ano | findstr "":8181 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    result = runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

            result = runCMD(@"netstat -ano | findstr "":9997 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    result = runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

            StartGateway();

            worker = new ServiceWorker();

            worker.Start();

            StartAgent();
        }
        #endregion

        #region Stop
        public void Stop()
        {
            worker.Stop();
            StopAgent();
            StopGateway();
        }
        #endregion

        #endregion

        #region Private

        #region CMD

        #region getPID
        private string getPID(string result)
        {
            string line = result.Split(new char[] { '\n', '\r' })[0];
            string[] items = line.Split(' ');
            try
            {
                int index = items.Length - 1;
                int pid = Int32.Parse(items[index]);
                return items[index];
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region runCMD
        private string runCMD(string command)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c " + command;
                p.Start();
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
            catch (Exception objException)
            {
                return null;
            }
        }
        #endregion

        #endregion

        #region Gateway

        #region StartGateway
        private void StartGateway()
        {
            Task.Factory.StartNew(() =>
            {
                process_gateway = new Process();

                process_gateway.StartInfo.FileName = "java";
                process_gateway.StartInfo.Arguments = @"-jar target/ogwapi-jar-with-dependencies.jar";
                process_gateway.StartInfo.WorkingDirectory = @"C:\VICINITY\Gateway";

                process_gateway.StartInfo.RedirectStandardOutput = true;
                process_gateway.StartInfo.RedirectStandardError = true;

                process_gateway.StartInfo.UseShellExecute = false;
                process_gateway.StartInfo.CreateNoWindow = true;
                process_gateway.EnableRaisingEvents = true;

                process_gateway.OutputDataReceived += Process_Gateway_OutputDataReceived;
                process_gateway.ErrorDataReceived += Process_Gateway_ErrorDataReceived;


                process_gateway.Start();

                try
                {
                    process_gateway.BeginErrorReadLine();
                    process_gateway.BeginOutputReadLine();
                }
                catch
                {
                    if (process_gateway != null)
                    {
                        try
                        {
                            ProcessHandling.StopProcess((uint)process_gateway.Id);
                        }
                        catch
                        { }

                        process_gateway.Close();
                        process_gateway.Dispose();
                    }
                }
            });
        }
        #endregion

        #region Process_Gateway_ErrorDataReceived
        private void Process_Gateway_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.ERROR, e.Data, LogAuthor.GTW);
        }
        #endregion

        #region Process_Gateway_OutputDataReceived
        private void Process_Gateway_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.INFO, e.Data, LogAuthor.GTW);
        }
        #endregion

        #region StopGateway
        private void StopGateway()
        {
            if (process_gateway != null)
            {
                try
                {
                    ProcessHandling.StopProcess((uint)process_gateway.Id);
                }
                catch
                { }

                process_gateway.Close();
                process_gateway.Dispose();
                process_gateway = null;
            }
        }
        #endregion

        #endregion

        #region Agent

        #region StartAgent
        private void StartAgent()
        {
            Task.Factory.StartNew(() =>
            {
                process_agent = new Process();

                process_agent.StartInfo.FileName = "java";
                process_agent.StartInfo.Arguments = @"-Dservice.config=config/service-config.json -Dagents.config=config/agents -Dserver.port=9997 -Dpersistence.file=config/db/thing.db -Dlogs.folder=logs -jar agent.jar";
                process_agent.StartInfo.WorkingDirectory = @"C:\VICINITY\Agent";

                process_agent.StartInfo.RedirectStandardOutput = true;
                process_agent.StartInfo.RedirectStandardError = true;

                process_agent.StartInfo.UseShellExecute = false;
                process_agent.StartInfo.CreateNoWindow = true;
                process_agent.EnableRaisingEvents = true;

                process_agent.OutputDataReceived += Process_agent_OutputDataReceived;
                process_agent.ErrorDataReceived += Process_agent_ErrorDataReceived;


                process_agent.Start();


                process_agent.BeginErrorReadLine();
                process_agent.BeginOutputReadLine();
            });
        }
        #endregion

        #region Process_agent_ErrorDataReceived
        private void Process_agent_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.ERROR, e.Data, LogAuthor.Agent);
        }
        #endregion

        #region Process_agent_OutputDataReceived
        private void Process_agent_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.INFO, e.Data, LogAuthor.Agent);
        }
        #endregion

        #region StopAgent
        private void StopAgent()
        {
            if (process_agent != null)
            {
                try
                {
                    ProcessHandling.StopProcess((uint)process_agent.Id);
                }
                catch
                { }

                process_agent.Close();
                process_agent.Dispose();
                process_agent = null;
            }
        }
        #endregion

        #endregion

        #endregion

        #endregion
    }
}
