using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModelConverter;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class DeviceReservationViewModel : BaseViewModel
    {
        private IInventoryStatProvide _inventoryStatProvide;

        public DeviceReservationViewModel()
        {
            ProceedCommand = new RelayCommand(Proceed);
            _inventoryStatProvide=new InventoryStatProvide();
            DeviceTypes = _inventoryStatProvide.GetDeviceTypes();
        }

        public List<DeviceType> DeviceTypes { get; set; }
        public ICommand ProceedCommand { get; set; }

        public DeviceType SelectedType { get; set; }

        public int Amount { get; set; }

        //public int Test { get; set; }

        //public TYPE Type { get; set; }

        public int Test { get; set; }



        private void Proceed()
        {
            var requestResult = _inventoryStatProvide.ReserveDevices(SelectedType.DeviceTypeId, Amount);
            if (requestResult.IsPossible)
            {
                MessageBox.Show("Devices Successfully reserved",
                    "success",
                    MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show(
                    $"Not enought device. only {requestResult.NumberOfAvailableDevice} devices are available for reservation",
                    "failure",
                    MessageBoxButton.OK);
            }
            IoC.Application.GoToPage(ApplicationPage.Dashboard);
        }
    }
}
