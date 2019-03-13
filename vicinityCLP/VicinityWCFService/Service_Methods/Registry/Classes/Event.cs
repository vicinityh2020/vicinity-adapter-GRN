using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VicinityWCF
{
    public class Event
    {
        #region Constructor
        public Event(string eID, string monitors, InOutput output)
        {
            EID = eID;
            Monitors = monitors;
            Output = output;
        }
        #endregion

        #region Properties

        #region Public

        #region EID
        [JsonProperty(PropertyName = "eid")]
        public string EID { set; get; }
        #endregion

        #region Monitors
        [JsonProperty(PropertyName = "monitors")]
        public string Monitors { set; get; }
        #endregion

        #region Output
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
