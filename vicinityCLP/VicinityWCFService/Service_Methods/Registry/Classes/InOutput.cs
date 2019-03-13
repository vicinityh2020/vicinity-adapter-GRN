

using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class InOutput
    {
        #region Constructor
        public InOutput(string type, List<Field> fields)
        {
            Type = type;
            Fields = fields;
        }
        #endregion

        #region Properties

        #region Public

        #region Type
        [JsonProperty(PropertyName = "type")]
        public string Type { set; get; }
        #endregion

        #region Fields
        [JsonProperty(PropertyName = "field")]
        public List<Field> Fields { set; get; }
        #endregion

        #endregion

        #endregion
    }
}
