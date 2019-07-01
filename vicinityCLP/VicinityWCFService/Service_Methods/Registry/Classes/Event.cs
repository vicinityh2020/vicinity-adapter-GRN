/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VicinityWCF
{
    public class Event
    {
        #region Constructor
        public Event(string eID, string monitors, InOutput output)
        {
            EID = eID;
            Monitors = monitors;
            Output = output;
        }
        #endregion

        #region Properties

        #region Public

        #region EID
        [JsonProperty(PropertyName = "eid")]
        public string EID { set; get; }
        #endregion

        #region Monitors
        [JsonProperty(PropertyName = "monitors")]
        public string Monitors { set; get; }
        #endregion

        #region Output
        [JsonProperty(PropertyName = "output")]
        public InOutput Output { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
