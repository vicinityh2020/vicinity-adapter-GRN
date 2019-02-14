using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vicinityCLP.Events.Classes
{
    public class Device
    {
        public Device(string auid, string oid, List<DeviceEvent> events, DeviceType deviceType)
        {
            AUID = auid;
            OID = oid;
            Events = events;
            DeviceType = deviceType;
        }
        public DeviceType DeviceType { get; set; }
        public string AUID { set; get; }
        public string OID { set; get; }
        public Dictionary<string, string> Properties { set; get; }
        public List<DeviceEvent> Events { get; set; }
    }
    public enum DeviceType
    {
        oven,
        refrigerator
    }
}
