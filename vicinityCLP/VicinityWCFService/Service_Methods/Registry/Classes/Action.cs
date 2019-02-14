using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VicinityWCF
{
    public class Action
    {
        [JsonProperty(PropertyName = "aid")]
        public string Aid { set; get; }
        [JsonProperty(PropertyName = "affects")]
        public string Affects { set; get; }
        [JsonProperty(PropertyName = "read_link")]
        public ReadWriteLink ReadLink { set; get; }
        [JsonProperty(PropertyName = "write_link")]
        public ReadWriteLink WriteLink { set; get; }
        public bool ShouldSerializeReadLink()
        {
            return ReadLink == null || (WriteLink.Output != null && ReadLink.Output.Field.Count == 0) ? false : true;
        }
    }
}
