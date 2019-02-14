using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Appliance
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { set; get; }
        [JsonProperty(PropertyName = "oid")]
        public string Oid { set; get; }
        [JsonProperty(PropertyName = "name")]
        public string Name { set; get; }
        [JsonProperty(PropertyName = "properties")]
        public List<Property> Properties { set; get; }
        [JsonProperty(PropertyName = "actions")]
        public List<Action> Actions { set; get; }
        [JsonProperty(PropertyName = "events")]
        public List<Event> Events { get; set; }
    }
}
