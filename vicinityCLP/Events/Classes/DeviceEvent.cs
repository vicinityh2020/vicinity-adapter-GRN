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
    public class DeviceEvent
    {
        #region Constructor
        public DeviceEvent(string clpid, string eid, List<EmergencyLevel> emergencyLevel)
        {
            CLPID = clpid;
            EID = eid;
            EmergencyLevel = emergencyLevel;
        }
        #endregion

        #region Properties

        #region Public

        #region EmergencyStage
        public EmergencyStage EmergencyStage { get; set; }
        #endregion

        #region EmergencyLevel
        public List<EmergencyLevel> EmergencyLevel { get; set; }
        #endregion

        #region LastChanged
        public DateTime LastChanged { get; set; }
        #endregion

        #region EID
        public string EID { set; get; }
        #endregion

        #region CLPID
        public string CLPID { set; get; }
        #endregion

        #endregion

        #endregion
    }
    public enum EmergencyStage
    {
        None,
        One,
        Two,
        Three
    }
    public enum CookingStatus
    {
        None,
        Baking,
        BakingFinished
    }
    public class EmergencyLevel
    {
        #region Constructor
        public EmergencyLevel(int min, EmergencyStage stage)
        {
            Min = min;
            Stage = stage;
        }
        #endregion

        #region Properties

        #region Public

        #region Min
        public int Min { get; set; }
        #endregion

        #region Stage
        public EmergencyStage Stage { get; set; }
        #endregion

        #endregion

        #endregion
    }
}
