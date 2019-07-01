/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
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
