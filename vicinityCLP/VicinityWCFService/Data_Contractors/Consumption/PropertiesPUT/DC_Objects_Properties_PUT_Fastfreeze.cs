using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_Fastfreeze
    {
        [DataMember(Name = "fastfreeze", IsRequired = true)]
        public string Fastfreeze { get; set; }
    }
    #endregion
}