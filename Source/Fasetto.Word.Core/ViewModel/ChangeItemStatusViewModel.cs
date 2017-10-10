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
    public class ChangeItemStatusViewModel : BaseViewModel
    {

        private IInventoryDeviceStatusProvider _inventoryDeviceStatusProvider;

        public ChangeItemStatusViewModel()
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
                _inventoryDeviceStatusProvider.ChangeStatusByRfid(Id, DeviceStatus.Loaned);
            }
            else if (SelectedIdType.Value == 2)
            {
                _inventoryDeviceStatusProvider.ChangeStatusBySerialNo(Id, DeviceStatus.Loaned);
            }
        }

        public IdType SelectedIdType { get; set; }

        public List<IdType> IdTypes { get; set; }

        public string Id { get; set; }

        public ICommand ChangeStatusCommand { get; set; }

        public bool IsFormValid => SelectedIdType != null
                           && !string.IsNullOrEmpty(Id);

    }

    public class IdType
    {
        public int Value { get; set; }

        public string ValueName { get; set; }

    }

}
