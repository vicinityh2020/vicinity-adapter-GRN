/**
Copyright © 2019 Gorenje gospodinjski aparati, d.o.o.. All rights reserved.
This file is part of vicinity-adapter-GRN.
#component# is free software: you can redistribute it and/or modify it under the terms of GNU General Public License v3.0.
THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT ANY WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT, IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
See README file for the full disclaimer information and LICENSE file for full license information in the project root.
**/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vicinityCLP.Events.Classes
{
    public class Device
    {
        #region Constructor
        public Device(string auid, string oid, List<DeviceEvent> events, DeviceType deviceType)
        {
            AUID = auid;
            OID = oid;
            Events = events;
            DeviceType = deviceType;
        }
        #endregion

        #region Properties

        #region Public

        #region DeviceType
        public DeviceType DeviceType { get; set; }
        #endregion

        #region AUID
        public string AUID { set; get; }
        #endregion

        #region OID
        public string OID { set; get; }
        #endregion

        #region Properties
        public Dictionary<string, string> Properties { set; get; }
        #endregion

        #region Events
        public List<DeviceEvent> Events { get; set; }
        #endregion

        #endregion

        #endregion
    }
    public enum DeviceType
    {
        oven,
        refrigerator
    }
}
