

using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class InOutput
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { set; get; }
        [JsonProperty(PropertyName = "field")]
        public List<Field> Field { set; get; }
    }
}
