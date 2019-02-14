using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_RefrigeratorTemp
    {
        [DataMember(Name = "refrigerator_temperature", IsRequired = true)]
        public string RefrigeratorTemp { get; set; }
    }
    #endregion
}