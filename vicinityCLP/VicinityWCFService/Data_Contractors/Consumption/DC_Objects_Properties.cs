using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT
    {
        [DataMember(Name = "input", IsRequired = true)]
        public List<DC_Objects_Properties_PUT_input> inputs { get; set; }
    }

    [DataContract(Name = "item", Namespace = "")]
    public class DC_Objects_Properties_PUT_input
    {
        [DataMember(Name = "parameterName", IsRequired = true)]
        public string name { get; set; }

        [DataMember(Name = "parameterValue", IsRequired = true)]
        public string value { get; set; }
    }

    #endregion
}