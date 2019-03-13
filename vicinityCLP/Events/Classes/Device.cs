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
