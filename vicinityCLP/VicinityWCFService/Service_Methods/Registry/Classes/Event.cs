using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VicinityWCF
{
    public class Event
    {
        [JsonProperty(PropertyName = "eid")]
        public string Eid { set; get; }
        [JsonProperty(PropertyName = "monitors")]
        public string Monitors { set; get; }
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
    }
}
