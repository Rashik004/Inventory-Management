using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public class InventoryListDesignModel:InventoryItemListViewModel
    {
        public static InventoryListDesignModel Instance => new InventoryListDesignModel();

        public InventoryListDesignModel()
        {
            Items=new List<InventoryItemViewModel>
            {
                new InventoryItemViewModel()
                {
                    ItemName = "Projector2",
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
