using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{

    #region POST method
    

    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_ActionsBaking
    {
        [DataMember(Name = "duration", IsRequired = true)]
        public string Duration { get; set; }
        [DataMember(Name = "temperature", IsRequired = true)]
        public string Temperature { get; set; }
        [DataMember(Name = "heater_system", IsRequired = true)]
        public string HeaterSystem { get; set; }
    }

    #endregion

}