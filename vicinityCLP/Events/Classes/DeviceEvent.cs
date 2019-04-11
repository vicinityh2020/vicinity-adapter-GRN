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
