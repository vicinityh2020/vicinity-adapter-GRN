using Newtonsoft.Json;
using System.Globalization;

namespace VicinityWCF
{
    public class StaticValue
    {
        #region Constructor
        public StaticValue(string pID, string type, object value)
        {
            PID = pID;
            StaticValueType = GetStaticValueTypeFromString(type);
            _property = pID + "_value";
            _value = value;
        }
        #endregion

        #region Properties

        #region Public

        #region PID
        [JsonIgnore]
        public string PID { get; set; }
        #endregion

        #region StaticValueType
        [JsonIgnore]
        public StaticValueType StaticValueType { get; set; }
        #endregion

        #region Property
        private string _property;
        [JsonProperty(PropertyName = "property")]
        public string Property
        {
            get
            {
                return _property;
            }
        }
        #endregion

        #region Value
        private object _value;
        [JsonProperty(PropertyName = "value")]
        public object Value
        {
            get
            {
                switch (StaticValueType)
                {
                    case StaticValueType.Double:
                        {
                            return double.Parse(_value.ToString(), CultureInfo.InvariantCulture);
                        }
                    default:
                        {
                            return null;
                        }
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region Methods

        #region Private

        #region GetStaticValueTypeFromString
        private StaticValueType GetStaticValueTypeFromString(string value)
        {
            if (value.CompareTo("double") == 0)
            {
                return StaticValueType.Double;
            }
            return StaticValueType.Null;
        }
        #endregion

        #endregion

        #endregion
    }
}
