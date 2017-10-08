using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public enum DeviceStatus
    {
        None=0,
        InStock=1,
        Reserved=2,
        Loaned=3,
        Maintanace=4,
        OutOfOrder=5
    }
}
