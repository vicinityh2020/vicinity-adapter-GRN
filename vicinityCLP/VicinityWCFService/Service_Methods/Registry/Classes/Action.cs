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
