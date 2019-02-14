using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_SetMeatProbeTemp
    {
        [DataMember(Name = "set_meat_probe_temperature", IsRequired = true)]
        public string MeatProbeTemp { get; set; }
    }
    #endregion
}