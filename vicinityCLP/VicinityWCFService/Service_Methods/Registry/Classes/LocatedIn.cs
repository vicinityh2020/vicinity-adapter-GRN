using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VicinityWCF
{
    public class LocatedIn
    {
        #region Constructor
        public LocatedIn(string locationType, string label, string locationID = null)
        {
            LocationType = locationType;
            Label = label;
            LocationID = locationID;
        }
        #endregion

        #region Properties

        #region Public

        #region LocationType
        [JsonProperty(PropertyName = "location_type")]
        public string LocationType { get; set; }
        #endregion

        #region Label
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
        #endregion

        #region LocationID
        [JsonProperty(PropertyName = "location_id")]
        public string LocationID { get; set; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializeLocationID
        public bool ShouldSerializeLocationID()
        {
            return !string.IsNullOrEmpty(LocationID);
        }
        #endregion

        #endregion

        #endregion
    }
}
