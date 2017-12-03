using System;
using System.Collections.Generic;
using System.Windows;
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

        private readonly IInventoryDeviceProvider _inventoryDeviceStatusProvider;


        public ICommand ConfirmCommand { get; set; }


        public string DeviceName { get; set; }

        public string DeviceType { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceStatus { get; set; }

        public ChoiceItem QueryOption { get; set; }

        public int SelectedDeviceStatusId { get; set; } 

        public string SeriaNo { get; set; }

        public string RFID { get; set; }

        public string Model { get; set; }

        public string DescriptionTitle { get; set; }

        public string Description { get; set; }

        public int ManufacturingYear { get; set; }


        public DeviceDetailsViewModel()
        {
            _inventoryDeviceStatusProvider = new InventoryDeviceProvider();

            ConfirmCommand = new RelayCommand(Confirm);

        }

        private void Confirm()
        {
            var result = false;
            if (QueryOption.Value == 1)
            {
                result = _inventoryDeviceStatusProvider.ChangeStatusByRfid(RFID, (DeviceStatus) SelectedDeviceStatusId,
                    LoggedInUserData.UserId);
            }
            else if (QueryOption.Value == 2)
            {
                result = _inventoryDeviceStatusProvider.ChangeStatusBySerialNo(SeriaNo, (DeviceStatus)SelectedDeviceStatusId,
                    LoggedInUserData.UserId);
            }
            if (result)
            {
                MessageBox.Show("Status Successfully Changed",
                        "success",
                        MessageBoxButton.OK); 
            }
            else
            {
                MessageBox.Show("Device is already reserved",
                    "Error",
                    MessageBoxButton.OK);
            }
            IoC.Application.GoToPage(ApplicationPage.ChangeStatus);
        }
    }
}