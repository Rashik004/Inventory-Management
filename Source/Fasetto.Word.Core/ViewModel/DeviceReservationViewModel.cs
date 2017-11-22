using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core.ViewModelConverter;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class DeviceReservationViewModel : BaseViewModel
    {
        private IInventoryStatProvide _inventoryStatProvide;

        public ObservableCollection<InventoryItemViewModel> Items { get; set; }
        //public TYPE Type { get; set; }

        public string Test { get; set; } = "Blah Blah";

        public DeviceReservationViewModel()
        {
            _inventoryStatProvide=new InventoryStatProvide();
            var itemList = _inventoryStatProvide.GetInventoryStatus().Select(ModelToViewModelConverter.InventoryItemStatConverter).ToList();
            Items=new ObservableCollection<InventoryItemViewModel>(itemList);
        }
    }
}
