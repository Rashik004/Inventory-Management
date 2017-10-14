using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }

        public string DeviceName { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }
    }
}
