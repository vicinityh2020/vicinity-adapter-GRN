using Newtonsoft.Json;
namespace VicinityWCF
{
    public class Property
    {
        #region Constructor
        public Property(string pID, string monitors, ReadWriteLink readLink, ReadWriteLink writeLink = null)
        {
            PID = pID;
            Monitors = monitors;
            ReadLink = readLink;
            WriteLink = writeLink;
        }
        #endregion

        #region Properties

        #region Public

        #region PID
        [JsonProperty(PropertyName = "pid")]
        public string PID { set; get; }
        #endregion

        #region Monitors
        [JsonProperty(PropertyName = "monitors")]
        public string Monitors { set; get; }
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

        #region ShouldSerializeWriteLink
        public bool ShouldSerializeWriteLink()
        {
            return WriteLink == null || (WriteLink.Input != null && WriteLink.Input.Fields.Count == 0 && WriteLink.Output != null && WriteLink.Output.Fields.Count == 0) ? false : true;
        }
        #endregion

        #endregion

        #endregion
    }
}
