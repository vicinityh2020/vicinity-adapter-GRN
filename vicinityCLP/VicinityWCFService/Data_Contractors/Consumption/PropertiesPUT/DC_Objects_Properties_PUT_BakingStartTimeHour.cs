using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_BakingStartTimeHour
    {
        [DataMember(Name = "baking_start_time_hour", IsRequired = true)]
        public string StartTimeHour { get; set; }
    }
    #endregion
}