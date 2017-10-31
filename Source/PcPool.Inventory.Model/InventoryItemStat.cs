using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public class InventoryItemStat
    {
        public string ItemName { get; set; }

        public int InStock { get; set; }

        public int Maintanace { get; set; }

        public int Loaned { get; set; }

        public int Total { get; set; }



    }
}
