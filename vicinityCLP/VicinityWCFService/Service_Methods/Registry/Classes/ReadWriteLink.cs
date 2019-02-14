
using Newtonsoft.Json;

namespace VicinityWCF
{
    public class ReadWriteLink
    {
        [JsonProperty(PropertyName = "href")]
        public string Href { set; get; }
        [JsonProperty(PropertyName = "input")]
        public InOutput Input { get; set; }
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
        public bool ShouldSerializeInput()
        {
            return (Input != null && Input.Field != null && Input.Field.Count > 0)  ? true : false;
        }
    }
}
