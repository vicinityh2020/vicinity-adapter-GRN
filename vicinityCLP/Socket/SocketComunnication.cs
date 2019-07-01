/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace vicinityCLP
{
    class SocketComunnication : IDisposable
    {
        //dispose
        private bool disposed = false;
        private SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        Socket listener;
        bool listening = true;
        bool _serverSetFlag = false;
        public event EventHandler StringListReceived;
        List<Thread> threads = new List<Thread>();
        List<ClientHandle> CHlist = new List<ClientHandle>();


        #region Public
        public void StartServer()
        {
            if (_serverSetFlag)
            {
                listener.Listen(10);
                Thread workerThread = new Thread(new ThreadStart(multyClient));
                threads.Add(workerThread);
                workerThread.Start();
            }
        }

        public void SetServer(int port, string ip)
        {
            try
            {
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(ip);
                IPEndPoint remoteEP = new IPEndPoint(ipaddress, port);
                listener.Bind(remoteEP);
                _serverSetFlag = true;

            }
            catch (Exception e)
            {
                _serverSetFlag = false;
            }
        }

        public void SetStartServer(int port, string ip)
        {
            listening = true;
            SetServer(port, ip);
            StartServer();
        }

        public void StopServer()
        {
            listening = false;
            listener.Close();
            foreach (ClientHandle CH in CHlist)
            {
                CH.StopClient();
                CH.PacketReceived -= CH_PacketReceived;
                CH.Dispose();
            }
            foreach (Thread t in threads)
            {
                if (t.IsAlive == true)
                {
                    t.Join();
                }
            }
        }

        public void Dispose()
        {
            StopServer();
            Dispose(true);
        }
        #endregion

        #region Private
        private void multyClient()
        {
            while (listening)
            {
                //if (listener.Connected == false)
                //  return;
                try
                {
                    Socket client = listener.Accept();
                    // Start a thread to handle this client...
                    Thread ctThread = new Thread(new ParameterizedThreadStart(addClient));
                    threads.Add(ctThread);
                    ctThread.Start(client);
                }
                catch
                { }
            }

        }

        private void addClient(object o)
        {
            Socket client = (Socket)o;
            ClientHandle CH = new ClientHandle();
            CHlist.Add(CH);
            CH.PacketReceived += CH_PacketReceived;
            CH.StartClient(client);
        }

        private void CH_PacketReceived(object sender, EventArgs e)
        {
            EventHandler eventhandel1 = StringListReceived;
            if (eventhandel1 != null)
            { eventhandel1(sender, EventArgs.Empty); }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                StopServer();
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
        #endregion
    }
}
