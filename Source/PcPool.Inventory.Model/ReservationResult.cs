using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public class ReservationResult
    {
        public bool IsPossible { get; set; }

        public int NumberOfAvailableDevice { get; set; }

    }
}
