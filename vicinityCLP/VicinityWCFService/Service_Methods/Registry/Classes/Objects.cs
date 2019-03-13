using Newtonsoft.Json;
using System.Collections.Generic;

namespace VicinityWCF
{
    public class Objects
    {
        #region Constructor
        public Objects(string adapterID, List<Appliance> appliances)
        {
            AdapterID = adapterID;
            Appliances = appliances;
        }
        #endregion

        #region Properties

        #region Public

        #region AdapterID
        [JsonProperty(PropertyName = "adapter-id")]
        public string AdapterID { get; set; }
        #endregion

        #region Appliances
        [JsonProperty(PropertyName = "thing-descriptions")]
        public List<Appliance> Appliances { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
