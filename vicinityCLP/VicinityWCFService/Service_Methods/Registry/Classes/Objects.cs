using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Objects
    {
        [JsonProperty(PropertyName = "adapter-id")]
        public string AdapterID { get; set; }
        [JsonProperty(PropertyName = "thing-descriptions")]
        public List<Appliance> Appliances { get; set; }

    }
}
