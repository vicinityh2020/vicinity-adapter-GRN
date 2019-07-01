/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace vicinityCLP
{
    class ClientHandle : IDisposable
    {
        //dispose
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        private object _msgsINLock = new object();
        List<List<string>> _msgsIN = new List<List<string>>();
        bool _msg_coplete = true;
        List<string> message = new List<string>();
        Socket client;
        bool _rwFlag = true;
        List<Thread> threads = new List<Thread>();
        public event EventHandler PacketReceived;

        Thread RThread;

        #region Public
        public void StartClient(Socket s)
        {
            client = s;
            Thread worker = new Thread(new ThreadStart(WorkerThread));
            threads.Add(worker);
            worker.Start();
        }

        public void StopClient()
        {
            _rwFlag = false;
            foreach (Thread t in threads)
            {
                if (t.IsAlive == true)
                {
                    t.Join();
                }
            }
        }


        public void Dispose()
        { this.Dispose(true); }

        public bool IsActive()
        {
            if (!client.Poll(1000, SelectMode.SelectRead))
                return true;
            return false;
        }
        #endregion

        #region Private
        private void WorkerThread()
        {
            while (_rwFlag)
            {
                try
                {
                    if (client.Connected)
                    {
                        //client conected
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
            RThread = new Thread(new ThreadStart(ReadThread));
            threads.Add(RThread);
            RThread.Start();
            List<List<string>> msgsIN = new List<List<string>>();
            while (_rwFlag)
            {
                try
                {
                    if (RThread.IsAlive != true)
                    { RThread.Start(); }
                }
                catch
                { }

                msgsIN.Clear();
                Thread.Sleep(10);
                lock (_msgsINLock)
                {
                    if (_msgsIN.Count > 0)
                    {
                        msgsIN = new List<List<string>>(_msgsIN);
                        _msgsIN = new List<List<string>>();
                    }
                }
                if (msgsIN.Count < 1)
                {
                    Thread.Sleep(5);
                }
                else
                {
                    foreach (List<string> LS in msgsIN)
                    {
                        foreach (string s in LS)
                        {
                            if (_msg_coplete || s=="<CLP>")
                            {
                                //new masg
                                if (s == "<CLP>")
                                {
                                    message.Clear();
                                    message.Add(s);
                                    _msg_coplete = false;
                                }

                            }
                            else
                            {
                                //complete old msg
                                if (s == "</CLP>")
                                {
                                    message.Add(s);
                                    _msg_coplete = true;
                                    EventHandler eventhandel = PacketReceived;
                                    if (eventhandel != null)
                                    { eventhandel(message, EventArgs.Empty); }
                                }
                                else
                                {
                                    message.Add(s);
                                }
                            }
                        }
                    }
                }
            }
            return;
        }

        private void ReadThread()
        {
            while (_rwFlag)
            {
                Thread.Sleep(1);
                try
                {
                    if (client.Connected)
                    {
                        break;
                    }
                }
                catch
                { }
            }
            List<string> msg = new List<string>();
            string temp_msg=string.Empty;
            char c;
            byte[] B = new byte[8];
            while (_rwFlag && client.Connected)
            {

                if (!client.Connected)
                {
                    return;
                }
                if (client.Available > 0)
                {
                    msg = new List<string>();
                    int bytesRead = client.Receive(B);
                    foreach (byte b in B)
                    {
                        c = Convert.ToChar(b);
                        if (c == '<')
                        {
                            msg.Add(temp_msg);
                            temp_msg = "<";
                        }
                        else if (c == '>')
                        {
                            temp_msg += ">";
                            msg.Add(temp_msg);
                            temp_msg = "";
                        }
                        else
                        {
                            temp_msg += c;
                        }
                    }
                    lock (_msgsINLock)
                    {
                        if (msg.Count > 0)
                        {
                            _msgsIN.Add(msg);
                        }
                    }
                }
                else
                { Thread.Sleep(10); }
            }
            return;
        }

        private string listToString(List<string> LS)
        {
            string s = "";
            foreach (string S in LS)
            { s += S; }
            return s;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                try
                {
                    StopClient();
                    handle.Dispose();
                    // Free any other managed objects here.
                    //
                }
                catch
                { }
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
