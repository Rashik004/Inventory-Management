using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class DashboardViewModel : BaseViewModel
    {
        public ObservableCollection<InventoryItemViewModel> Items { get; set; }
        //public TYPE Type { get; set; }

        public string Test { get; set; } = "Blah Blah";

        public DashboardViewModel()
        {
            Items = new ObservableCollection<InventoryItemViewModel>
            {
                 new InventoryItemViewModel()
                {
                    ItemName = "Projector42",
                    InStockCount = 420,
                    LoanedCount = 40,
                    MaintanaceCount = 23
                },
                new InventoryItemViewModel()
                {
                    ItemName = "Projector3",
                    InStockCount = 420,
                    LoanedCount = 40,
                    MaintanaceCount = 23
                },
                new InventoryItemViewModel()
                {
                    ItemName = "Projector4",
                    InStockCount = 420,
                    LoanedCount = 40,
                    MaintanaceCount = 23
                },
                new InventoryItemViewModel()
                {
                    ItemName = "Projector5",
                    InStockCount = 420,
                    LoanedCount = 40,
                    MaintanaceCount = 23
                },
            };
        }
    }
}
