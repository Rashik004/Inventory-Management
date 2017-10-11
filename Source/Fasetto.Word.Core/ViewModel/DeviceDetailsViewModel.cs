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

        private IInventoryDeviceStatusProvider _inventoryDeviceStatusProvider;

        public DeviceDetailsViewModel()
        {
            _inventoryDeviceStatusProvider=new InventoryDeviceProvider();
            ChangeStatusCommand=new RelayCommand(ChangeStatus);
            IdTypes=new List<IdType>
            {
                new IdType()
                {
                    ValueName = "RFID",
                    Value = 1,
                },
                new IdType()
                {
                    ValueName = "Serial No",
                    Value=2
                }
            };    
        }

        private void ChangeStatus()
        {
            if (SelectedIdType.Value == 1)
            {
                _inventoryDeviceStatusProvider.ChangeStatusByRfid(Id, DeviceStatus.Loaned, LoggedInUserData.UserId);
            }
            else if (SelectedIdType.Value == 2)
            {
                _inventoryDeviceStatusProvider.ChangeStatusBySerialNo(Id, DeviceStatus.Loaned, LoggedInUserData.UserId);
            }
        }

        public IdType SelectedIdType { get; set; }

        public List<IdType> IdTypes { get; set; }

        public string Id { get; set; }

        public ICommand ChangeStatusCommand { get; set; }

        public bool IsFormValid => SelectedIdType != null
                                   && !string.IsNullOrEmpty(Id);

    }
}