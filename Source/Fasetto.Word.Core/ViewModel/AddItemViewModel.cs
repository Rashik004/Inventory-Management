using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModelConverter;
using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceInstance = PcPool.Inventory.Model.DeviceInstance;
using DeviceType = PcPool.Inventory.Model.DeviceType;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class AddItemViewModel : BaseViewModel
    {
        public string SerialNo { get; set; }

        public string RFID { get; set; }


        public string Description { get; set; }

        public List<DeviceType> DeviceTypes { get; set; }

        public DeviceType SelectedDeviceType { get; set; }

        public bool IsFormValid => SelectedDeviceType != null
                                   && !string.IsNullOrEmpty(RFID)
                                   && !string.IsNullOrEmpty(SerialNo);

        public ICommand AddItemCommand { get; set; }


        private IInventoryStatProvide _inventoryStatProvide;

        private IInventoryDeviceProvider _inventoryDeviceStatusProvider;


        public AddItemViewModel()
        {
            _inventoryStatProvide=new InventoryStatProvide();
            _inventoryDeviceStatusProvider=new InventoryDeviceProvider();
            DeviceTypes =_inventoryStatProvide.GetDeviceTypes();
            AddItemCommand=new RelayCommand(AddItem);
        }

        private void AddItem()
        {
            _inventoryDeviceStatusProvider.AddnewItem(new DeviceInstance()
            {
                DeviceTypeId = SelectedDeviceType.DeviceTypeId,
                DeviceStatus = DeviceStatus.InStock,
                //DeviceName = "New from UI",
                Description = Description,
                RFID = RFID,
                SeriaNo = SerialNo,
                DescriptionTitle = Description
            });
            IoC.Application.GoToPage(ApplicationPage.ChangeStatus);
        }
    }
}
