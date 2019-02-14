using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_AlarmTime
    {
        [DataMember(Name = "alarm_time", IsRequired = true)]
        public string AlarmTime { get; set; }
    }
    #endregion
}