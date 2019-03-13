using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VicinityWCF
{
    public class Action
    {
        #region Constructor
        public Action(string aID, string affects, ReadWriteLink writeLink, ReadWriteLink readLink = null)
        {
            AID = aID;
            Affects = affects;
            WriteLink = writeLink;
            ReadLink = readLink;
        }
        #endregion

        #region Properties

        #region Public

        #region AID
        [JsonProperty(PropertyName = "aid")]
        public string AID { set; get; }
        #endregion

        #region Affects
        [JsonProperty(PropertyName = "affects")]
        public string Affects { set; get; }
        #endregion

        #region ReadLink
        [JsonProperty(PropertyName = "read_link")]
        public ReadWriteLink ReadLink { set; get; }
        #endregion

        #region WriteLink
        [JsonProperty(PropertyName = "write_link")]
        public ReadWriteLink WriteLink { set; get; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializeReadLink
        public bool ShouldSerializeReadLink()
        {
            return ReadLink == null || (WriteLink.Output != null && ReadLink.Output.Fields.Count == 0) ? false : true;
        }
        #endregion

        #endregion

        #endregion
    }
}
