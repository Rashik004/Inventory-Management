using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.Inventory.Model;

namespace PcPool.Inventory.BusinessLayer.Interfaces
{
    public interface IInventoryStatProvide
    {
        IList<InventoryItemStat> GetInventoryStatus();

        List<DeviceType> GetDeviceTypes();

        ReservationResult ReserveDevices(int deviceTypeId, int amount, int userId = -1, bool checkOnly = false);
    }
}
