using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_ChildLock
    {
        [DataMember(Name = "child_lock", IsRequired = true)]
        public string ChildLock { get; set; }
    }
    #endregion
}