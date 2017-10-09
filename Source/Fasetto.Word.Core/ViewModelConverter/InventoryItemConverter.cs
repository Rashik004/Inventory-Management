using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core.ViewModelConverter
{
    public static class InventoryItemConverter
    {
        public static InventoryItemViewModel InventoryItemStatConverter(InventoryItemStat arg)
        {
            return new InventoryItemViewModel()
            {
                ItemName = arg.ItemName,
                InStockCount = arg.InStock,
                MaintanaceCount = arg.Maintanace
            };
        }
    }
}
