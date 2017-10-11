using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    public class DeviceDetailsViewModel:BaseViewModel
    {
        private IInventoryDeviceStatusProvider _inventoryDeviceStatusProvider;

        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public DeviceStatus DeviceStatus { get; set; }

        public string SeriaNo { get; set; }

        public string RFID { get; set; }

        public string Model { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

        public int ManufacturingYear { get; set; }


    }
}
