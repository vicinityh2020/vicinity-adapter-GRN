/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
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
