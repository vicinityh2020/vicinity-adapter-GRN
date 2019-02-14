using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_SetBakingTime
    {
        [DataMember(Name = "set_baking_time", IsRequired = true)]
        public string BakingTime { get; set; }
    }
    #endregion
}