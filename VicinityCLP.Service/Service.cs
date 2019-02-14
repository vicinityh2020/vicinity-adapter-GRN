using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace VicinityCLP.Service
{
    partial class Service : ServiceBase
    {
        private static Client _client;
        public Service()
        {
            InitializeComponent();
        }
        
        protected override void OnStart(string[] args)
        {
            _client = new Client();
            _client.Start();
        }

        protected override void OnStop()
        {
            _client.Stop();
            _client = null;
        }
    }
}
