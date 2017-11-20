using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModelConverter;
//using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceInstance = PcPool.Inventory.Model.DeviceInstance;
using DeviceType = PcPool.Inventory.Model.DeviceType;
using System.Windows;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class ChangeItemStatusViewModel : BaseViewModel
    {

        private readonly IInventoryDeviceProvider _inventoryDeviceStatusProvider;

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
                    Value = 3,
                },
                new ChoiceItem()
                {
                    ValueName = "Maintanace",
                    Value = 4
                },
                new ChoiceItem()
                {
                    ValueName = "Out Of Order",
                    Value = 5
                }
            };
            ProceedCommand=new RelayCommand(Proceed);
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

        private void Proceed()
        {
            //Devi

            var deviceInstance = SelectedStatus.Value == 1
                ? _inventoryDeviceStatusProvider.GetItemByRfid(Id)
                : _inventoryDeviceStatusProvider.GetItemBySerialId(Id);
            if (deviceInstance == null)
            {
                MessageBox.Show("No device found with given Id",
                    "No Device Found",
                    MessageBoxButton.OK);
                return;
            }
            var deviceDetailsViewModel = new DeviceDetailsViewModel()
            {
                DeviceName = deviceInstance.DeviceName,
                DeviceType = deviceInstance.DeviceType,
                DeviceTypeId = deviceInstance.DeviceTypeId,
                DeviceStatus =  deviceInstance.DeviceStatus.ToString(),
                Description = deviceInstance.Description,
                DescriptionTitle = deviceInstance.Description,
                SeriaNo = deviceInstance.SeriaNo,
                RFID = deviceInstance.RFID,
                ManufacturingYear = deviceInstance.ManufacturingYear,
                Model = deviceInstance.Model,
                SelectedDeviceStatusId = SelectedStatus.Value
            };
            IoC.Application.GoToPage(ApplicationPage.DeviceDetails, deviceDetailsViewModel);
        }

        public ChoiceItem SelectedIdType { get; set; }

        public ChoiceItem SelectedStatus { get; set; }


        public List<ChoiceItem> IdTypes { get; set; }

        public List<ChoiceItem> StatusTypes { get; set; }

        public string Id { get; set; }

        public ICommand ProceedCommand { get; set; }

        public bool IsFormValid => SelectedIdType != null
                           && !string.IsNullOrEmpty(Id);

    }

    public class ChoiceItem
    {
        public int Value { get; set; }

        public string ValueName { get; set; }

    }

}
