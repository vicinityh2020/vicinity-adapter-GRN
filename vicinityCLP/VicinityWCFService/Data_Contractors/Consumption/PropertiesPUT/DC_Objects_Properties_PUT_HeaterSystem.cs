using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_HeaterSystem
    {
        [DataMember(Name = "heater_system", IsRequired = true)]
        public string HeaterSystem { get; set; }
    }
    #endregion
}