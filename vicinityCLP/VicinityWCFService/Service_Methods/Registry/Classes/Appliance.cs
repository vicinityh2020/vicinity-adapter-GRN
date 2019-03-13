using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Appliance
    {
        #region Constructor
        public Appliance(string type, string oid, string name, List<Property> properties, List<Action> actions, List<Event> events, List<LocatedIn> locatedIn)
        {
            Type = type;
            OID = oid;
            Name = name;
            Properties = properties;
            Actions = actions;
            Events = events;
            LocatedIn = locatedIn;
        }
        #endregion

        #region Properties

        #region Public

        #region Type
        [JsonProperty(PropertyName = "type")]
        public string Type { set; get; }
        #endregion

        #region OID
        [JsonProperty(PropertyName = "oid")]
        public string OID { set; get; }
        #endregion

        #region Name
        [JsonProperty(PropertyName = "name")]
        public string Name { set; get; }
        #endregion

        #region LocatedIn
        [JsonProperty(PropertyName = "located-in")]
        public List<LocatedIn> LocatedIn { get; set; }
        #endregion

        #region Properties
        [JsonProperty(PropertyName = "properties")]
        public List<Property> Properties { set; get; }
        #endregion

        #region Actions
        [JsonProperty(PropertyName = "actions")]
        public List<Action> Actions { set; get; }
        #endregion

        #region Events
        [JsonProperty(PropertyName = "events")]
        public List<Event> Events { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
