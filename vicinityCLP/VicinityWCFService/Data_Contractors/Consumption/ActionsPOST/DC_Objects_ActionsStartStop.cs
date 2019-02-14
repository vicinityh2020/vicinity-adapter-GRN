using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{

    #region POST method
    

    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_ActionsStartStop
    {
        [DataMember(Name = "id", IsRequired = true)]
        public string ID { get; set; }
    }

    #endregion

}