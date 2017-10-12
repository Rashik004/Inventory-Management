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
            StatusTypes = new List<ChoiceItem>()
            {
                new ChoiceItem()
                {
                    ValueName = "In Stock",
                    Value = 1,
                },
                new ChoiceItem()
                {
                    ValueName = "Loaned",
                    Value = 1,
                },
                new ChoiceItem()
                {
                    ValueName = "Maintanace",
                    Value = 2
                },
                new ChoiceItem()
                {
                    ValueName = "Out Of Order",
                    Value = 2
                }
            };
            ChangeStatusCommand=new RelayCommand(ChangeStatus);
            IdTypes=new List<ChoiceItem>
            {
                new ChoiceItem()
                {
                    ValueName = "RFID",
                    Value = 1,
                },
                new ChoiceItem()
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
                _inventoryDeviceStatusProvider.ChangeStatusByRfid(Id, (DeviceStatus) SelectedStatus.Value,
                    LoggedInUserData.UserId);
            }
            else if (SelectedIdType.Value == 2)
            {
                _inventoryDeviceStatusProvider.ChangeStatusBySerialNo(Id, (DeviceStatus) SelectedStatus.Value,
                    LoggedInUserData.UserId);
            }
            IoC.Application.GoToPage(ApplicationPage.ChangeStatus);
        }

        public ChoiceItem SelectedIdType { get; set; }

        public ChoiceItem SelectedStatus { get; set; }


        public List<ChoiceItem> IdTypes { get; set; }

        public List<ChoiceItem> StatusTypes { get; set; }

        public string Id { get; set; }

        public ICommand ChangeStatusCommand { get; set; }

        public bool IsFormValid => SelectedIdType != null
                           && !string.IsNullOrEmpty(Id);

    }

    public class ChoiceItem
    {
        public int Value { get; set; }

        public string ValueName { get; set; }

    }

}
