using Newtonsoft.Json;

namespace VicinityWCF
{
    public class Field
    {
        #region Constructor
        public Field(string name, string description, Schema schema, string predicate = null)
        {
            Name = name;
            Description = description;
            Schema = schema;
            Predicate = predicate;
        }
        #endregion

        #region Properties

        #region Public

        #region Name
        [JsonProperty(PropertyName = "name")]
        public string Name { set; get; }
        #endregion

        #region Predicate
        [JsonProperty(PropertyName = "predicate")]
        public string Predicate { set; get; }
        #endregion

        #region Description
        [JsonProperty(PropertyName = "description")]
        public string Description { set; get; }
        #endregion

        #region Schema
        [JsonProperty(PropertyName = "schema")]
        public Schema Schema { set; get; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializePredicate
        public bool ShouldSerializePredicate()
        {
            return !string.IsNullOrEmpty(Predicate);
        }
        #endregion

        #endregion

        #endregion
    }
}
