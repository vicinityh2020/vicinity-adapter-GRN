using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vicinityCLP.Events.Classes
{
    public class DeviceEvent
    {
        public DeviceEvent(string clpid, string eid, List<EmergencyLevel> emergencyLevel)
        {
            CLPID = clpid;
            EID = eid;
            EmergencyLevel = emergencyLevel;
        }
        public CookingStatus CookingStatus { get; set; }
        public EmergencyStage EmergencyStage { get; set; }
        public List<EmergencyLevel> EmergencyLevel { get; set; }
        public DateTime LastChanged { get; set; }
        public string EID { set; get; }
        public string CLPID { set; get; }
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
        BakingFinished
    }
    public class EmergencyLevel
    {
        public EmergencyLevel(int min, EmergencyStage stage)
        {
            Min = min;
            Stage = stage;
        }
        public int Min { get; set; }
        public EmergencyStage Stage { get; set; }
    }
}
