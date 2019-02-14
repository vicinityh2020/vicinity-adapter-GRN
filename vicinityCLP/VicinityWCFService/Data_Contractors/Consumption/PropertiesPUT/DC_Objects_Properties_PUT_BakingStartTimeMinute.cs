using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_BakingStartTimeMinute
    {
        [DataMember(Name = "baking_start_time_minute", IsRequired = true)]
        public string StartTimeMinute { get; set; }
    }
    #endregion
}