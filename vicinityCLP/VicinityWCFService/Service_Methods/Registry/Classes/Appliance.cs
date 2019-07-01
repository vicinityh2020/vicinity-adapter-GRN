/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
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
