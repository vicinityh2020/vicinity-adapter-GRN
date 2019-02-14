using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_SetBakingTemp
    {
        [DataMember(Name = "set_baking_temperature", IsRequired = true)]
        public string BakingTemp { get; set; }
    }
    #endregion
}