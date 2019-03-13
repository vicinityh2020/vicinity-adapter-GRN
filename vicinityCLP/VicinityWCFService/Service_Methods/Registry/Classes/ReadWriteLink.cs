
using Newtonsoft.Json;

namespace VicinityWCF
{
    public class ReadWriteLink
    {
        #region Constructor
        public ReadWriteLink(string href, InOutput output, InOutput input = null)
        {
            Href = href;
            Output = output;
            Input = input;
        }
        #endregion

        #region Properties

        #region Public

        #region Href
        [JsonProperty(PropertyName = "href")]
        public string Href { set; get; }
        #endregion

        #region StaticValue
        [JsonProperty(PropertyName = "static-value")]
        public StaticValue StaticValue { get; set; }
        #endregion

        #region Input
        [JsonProperty(PropertyName = "input")]
        public InOutput Input { get; set; }
        #endregion

        #region Output
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Public

        #region ShouldSerializeInput
        public bool ShouldSerializeInput()
        {
            return Input != null && Input.Fields != null && Input.Fields.Count > 0;
        }
        #endregion

        #region ShouldSerializeStaticValue
        public bool ShouldSerializeStaticValue()
        {
            return StaticValue != null && !string.IsNullOrEmpty(StaticValue.Property) && StaticValue.Value != null;
        }
        #endregion

        #endregion

        #endregion
    }
}
