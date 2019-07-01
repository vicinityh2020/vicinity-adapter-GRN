/**
Copyright © #YYYY#[1] Company. All rights reserved.
This file is part of #component#.
#component# is free software: you can redistribute it and/or modify it under the terms of #license#.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using vicinityCLP;

namespace VicinityCLP
{
    public partial class Form1 : Form
    {
        Process process_gateway;
        Process process_agent;

        ServiceWorker worker;

        public Form1()
        {
            InitializeComponent();
        }

        #region CMD
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

        private string runCMD(string command)
        {
            try
            {
                // Start the child process.
                Process p = new Process();
                // Redirect the output stream of the child process.
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c "+command;
                p.Start();
                // Do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                // p.WaitForExit();
                // Read the output stream first and then wait.
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                return output;
            }
            catch (Exception objException)
            {
                // Log the exception
                return null;
            }
        }
        #endregion

        private void btnStartService_Click(object sender, EventArgs e)
        {
            worker = new ServiceWorker();
            worker.Start();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            worker.Stop();
        }

        private void ShowGatewayLog(string text)
        {
            try
            {
                string _text = text;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _text)));
                }
                else
                {
                    AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _text);
                }
            }
            catch
            { }
        }

        private void ShowGatewayError(string text)
        {
            try
            {
                string _text = text;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _text)));
                }
                else
                {
                    AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _text);
                }
            }
            catch
            { }
        }

        private void ShowGatewayException(Exception ex)
        {
            try
            {
                Exception _ex = ex;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _ex.Message, true)));
                    Invoke(new Action(() => AddToRichTextBox(rtbErrorGateway, _ex.StackTrace)));
                }
                else
                {
                    AddToRichTextBox(rtbErrorGateway, AddTimeStamp() + _ex.Message, true);
                    AddToRichTextBox(rtbErrorGateway, _ex.StackTrace);
                }
            }
            catch
            { }
        }

        private void ShowAgentLog(string text)
        {
            try
            {
                string _text = text;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAgent, AddTimeStamp() + _text)));
                }
                else
                {
                    AddToRichTextBox(rtbLogAgent, AddTimeStamp() + _text);
                }
            }
            catch
            { }
        }

        private void ShowAgentError(string text)
        {
            try
            {
                string _text = text;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbErrorAgent, AddTimeStamp() + _text)));
                }
                else
                {
                    AddToRichTextBox(rtbErrorAgent, AddTimeStamp() + _text);
                }
            }
            catch
            { }
        }

        private void ShowAgentException(Exception ex)
        {
            try
            {
                Exception _ex = ex;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAgent, AddTimeStamp() + _ex.Message, true)));
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAgent, _ex.StackTrace)));
                }
                else
                {
                    AddToRichTextBox(rtbLogAgent, AddTimeStamp() + _ex.Message, true);
                    AddToRichTextBox(rtbLogAgent, _ex.StackTrace);
                }
            }
            catch
            { }
        }

        private void ShowAdapterLog(string text)
        {
            try
            {
                string _text = text;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAdapter, AddTimeStamp() + _text)));
                }
                else
                {
                    AddToRichTextBox(rtbLogAdapter, AddTimeStamp() + _text);
                }
            }
            catch
            { }
        }

        private void ShowAdapterException(Exception ex)
        {
            try
            {
                Exception _ex = ex;

                if (InvokeRequired)
                {
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAdapter, AddTimeStamp() + _ex.Message, true)));
                    Invoke(new Action(() => AddToRichTextBox(rtbLogAdapter, _ex.StackTrace)));
                }
                else
                {
                    AddToRichTextBox(rtbLogAdapter, AddTimeStamp() + _ex.Message, true);
                    AddToRichTextBox(rtbLogAdapter, _ex.StackTrace);
                }
            }
            catch
            { }
        }

        private string AddTimeStamp()
        {
            string text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            while (text.Length < 30)
            {
                text += " ";
            }

            return text;
        }

        private void AddToRichTextBox(RichTextBox rtb, string text, bool is_exception = false)
        {
            if (!String.IsNullOrEmpty(rtb.Text))
            {
                rtb.AppendText(Environment.NewLine);
            }


            if (is_exception)
            {
                rtb.AppendText(text, Color.Red);
            }
            else
            {
                rtb.AppendText(text);
            }


            rtb.SelectionStart = rtb.Text.Length;
            rtb.ScrollToCaret();
        }


        #region Gateway process

        private void btnJAVAStartGateway_Click(object sender, EventArgs e)
        {
            process_gateway = null;
            process_agent = null;

            string result = runCMD(@"netstat -ano | findstr "":8181 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

            result = runCMD(@"netstat -ano | findstr "":9997 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

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

        private void Process_Gateway_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.ERROR, e.Data, LogAuthor.GTW);
        }

        private void Process_Gateway_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.INFO, e.Data, LogAuthor.GTW);
        }

        private void btnJAVAStopGateway_Click(object sender, EventArgs e)
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

        #endregion


        #region Agent process

        private void btnJAVAStartAgent_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                process_agent = new Process();

                process_agent.StartInfo.FileName = "java";
                // process_agent.StartInfo.Arguments = @"-Dconfig.file=config/agents/config-gorenje.json -Dregister.on.startup=false -Dagent.id=3ec72185-575b-404f-853b-0ba7dd9c3d30 -Dserver.port=9997 -jar bin/agent.jar";
                //   process_agent.StartInfo.Arguments = @"-Dconfig.file=bin/service-config.json -Dregister.on.startup=false -Dagent.id=cbc414ca-9512-4339-895b-ebc4175de2f3 -Dserver.port=9997 -jar target/agent.jar";
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

        private void Process_agent_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.ERROR, e.Data, LogAuthor.Agent);
        }

        private void Process_agent_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Log(LogMsgType.INFO, e.Data, LogAuthor.Agent);
        }

        private void btnJAVAStopAgent_Click(object sender, EventArgs e)
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
            }
        }

        #endregion


        private void btnClearAll_Click(object sender, EventArgs e)
        {
            rtbLogAgent.Clear();
            rtbErrorAgent.Clear();

            rtbErrorGateway.Clear();

            rtbLogAdapter.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Open form 2
            Form2 objUI = new Form2();
            objUI.ShowDialog();

        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {

            process_gateway = null;
            process_agent = null;

            string result = runCMD(@"netstat -ano | findstr "":8181 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

            result = runCMD(@"netstat -ano | findstr "":9997 """);
            if (!string.IsNullOrEmpty(result))
            {
                string pid = getPID(result);
                if (!string.IsNullOrEmpty(pid))
                {
                    runCMD(@"taskkill /PID " + pid + " /F");
                }
            }

            btnJAVAStartGateway_Click(this, null);

            worker = new ServiceWorker();

            worker.Start();

            btnJAVAStartAgent_Click(this, null);
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            worker.Stop();
            btnJAVAStopAgent_Click(this, null);
            btnJAVAStopGateway_Click(this, null);
        }
    }
}
