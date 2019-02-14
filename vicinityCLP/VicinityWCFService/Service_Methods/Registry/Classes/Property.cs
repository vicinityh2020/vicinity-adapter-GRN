using Newtonsoft.Json;
namespace VicinityWCF
{
    public class Property
    {
        [JsonProperty(PropertyName = "pid")]
        public string Pid { set; get; }
        [JsonProperty(PropertyName = "monitors")]
        public string Monitors { set; get; }
        [JsonProperty(PropertyName = "read_link")]
        public ReadWriteLink ReadLink { set; get; }
        [JsonProperty(PropertyName = "write_link")]
        public ReadWriteLink WriteLink { set; get; }
        public bool ShouldSerializeWriteLink()
        {
            return WriteLink == null || (WriteLink.Input != null && WriteLink.Input.Field.Count == 0 && WriteLink.Output != null && WriteLink.Output.Field.Count == 0) ? false : true;
        }
    }
}
