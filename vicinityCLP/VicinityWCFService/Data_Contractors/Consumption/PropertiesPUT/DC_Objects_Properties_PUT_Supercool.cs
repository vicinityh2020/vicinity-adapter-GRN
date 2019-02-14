using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_Supercool
    {
        [DataMember(Name = "supercool", IsRequired = true)]
        public string Supercool { get; set; }
    }
    #endregion
}