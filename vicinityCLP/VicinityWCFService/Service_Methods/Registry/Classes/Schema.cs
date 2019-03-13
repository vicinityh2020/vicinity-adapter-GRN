using Newtonsoft.Json;

namespace VicinityWCF
{
    public class Schema
    {
        #region Constructor
        public Schema(string type)
        {
            Type = type;
        }
        #endregion

        #region Properties

        #region Public

        #region Type
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
