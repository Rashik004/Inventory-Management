using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public class DeviceInstance : ModelBase
    {
        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public int DeviceTypeId { get; set; }


        public DeviceStatus DeviceStatus { get; set; }

        public string SeriaNo { get; set; }

        public string RFID { get; set; }

        public string Model { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

    }
}
