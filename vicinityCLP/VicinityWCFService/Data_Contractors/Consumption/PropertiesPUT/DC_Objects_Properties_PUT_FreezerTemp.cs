using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_FreezerTemp
    {
        [DataMember(Name = "freezer_temperature", IsRequired = true)]
        public string FreezerTemp { get; set; }
    }
    #endregion
}