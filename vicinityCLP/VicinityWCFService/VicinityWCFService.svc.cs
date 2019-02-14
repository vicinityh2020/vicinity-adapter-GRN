using System;
using System.ServiceModel;

namespace VicinityWCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public partial class VicinityWCFService : IVicinityWCFService
    {
        public event EventHandler<HTTPRequestEventArgs> OnRequestReceived;

        public VicinityWCFService()
        {
            OnRequestReceived = null;
        }
    }
}
