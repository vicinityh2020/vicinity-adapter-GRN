using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{

    #region POST method
    

    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Actions_POST
    {
        [DataMember(Name = "input", IsRequired = true)]
        public List<DC_Objects_Actions_POST_input> inputs { get; set; }
    }


    [DataContract(Name = "item", Namespace = "")]
    public class DC_Objects_Actions_POST_input
    {
        [DataMember(Name = "parameterName", IsRequired = true)]
        public string name { get; set; }

        [DataMember(Name = "parameterValue", IsRequired = true)]
        public string value { get; set; }
    }

    #endregion

}