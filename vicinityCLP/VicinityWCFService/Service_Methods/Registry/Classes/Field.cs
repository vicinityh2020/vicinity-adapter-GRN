using Newtonsoft.Json;

namespace VicinityWCF
{
    public class Field
    {
        public Field(string name, string description, Schema schema, string predicate = null)
        {
            Name = name;
            Description = description;
            Schema = schema;
            Predicate = predicate;
        }
        [JsonProperty(PropertyName = "name")]
        public string Name { set; get; }
        [JsonProperty(PropertyName = "predicate")]
        public string Predicate { set; get; }
        [JsonProperty(PropertyName = "description")]
        public string Description { set; get; }
        [JsonProperty(PropertyName = "schema")]
        public Schema Schema { set; get; }
        public bool ShouldSerializePredicate()
        {
            return (string.IsNullOrEmpty(Predicate)) ? false : true;
        }
    }
    public class Schema
    {
        public Schema(string type)
        {
            Type = type;
        }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
