﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VicinityWCF
{
    #region PUT method

    
    [DataContract(Name = "root", Namespace = "")]
    public class DC_Objects_Properties_PUT_Light
    {
        [DataMember(Name = "light", IsRequired = true)]
        public string Light { get; set; }
    }
    #endregion
}