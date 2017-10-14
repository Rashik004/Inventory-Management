using System.Collections.Generic;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class DeviceDetailsViewModel : BaseViewModel
    {

        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public int DeviceStatusId { get; set; }

        public int SelectedDeviceStatusId { get; set; } 

        public string SeriaNo { get; set; }

        public string RFID { get; set; }

        public string Model { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

        public int ManufacturingYear { get; set; }



    }
}