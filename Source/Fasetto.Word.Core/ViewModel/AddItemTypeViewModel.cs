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
    public class AddItemTypeViewModel:BaseViewModel
    {
        private IInventoryDeviceStatusProvider _inventoryDeviceStatusProvider;

        public ICommand AddItemTypeCommand { get; set; }

        public int DeviceTypeId { get; set; }

        public string DevicaeName { get; set; }

        public string DeviceDescription { get; set; }

        public string Model { get; set; }

        public string Version { get; set; }

        public string Description { get; set; }

        public AddItemTypeViewModel()
        {
            _inventoryDeviceStatusProvider=new InventoryDeviceProvider();
            AddItemTypeCommand=new RelayCommand(AddItemType);
        }

        private void AddItemType()
        {
            _inventoryDeviceStatusProvider.AddnewItemType(new DeviceType()
            {
                Description = Description,
                DeviceName = DevicaeName
            });
        }
    }
}
