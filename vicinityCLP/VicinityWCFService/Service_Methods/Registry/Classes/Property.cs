/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
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
