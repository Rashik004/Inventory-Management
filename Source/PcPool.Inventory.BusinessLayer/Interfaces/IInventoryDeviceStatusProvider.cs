using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.Inventory.Model;

namespace PcPool.Inventory.BusinessLayer.Interfaces
{
    public interface IInventoryDeviceStatusProvider
    {
        //IList<DeviceInstance> GetAll();
        bool AddnewItem(DeviceInstance deviceInstance);

        IList<DeviceInstance> GetAll(DeviceStatus deviceStatus, int deviceTypeId=0);

        bool ChangeStatusBySerialNo(string serialNo, DeviceStatus newStatus);

        bool ChangeStatusByRfid(string rfid, DeviceStatus newStatus);


        bool ChangeStatus(int deviceId, IList<DeviceStatus> newStatus);

        bool ChangeDeviceStatusByDeviceType(int deviceTypeId, int deviceCount);

        bool IsTransitionPossible(int deviceId, DeviceStatus newStatus);

        bool IsTransitionPossible(int deviceId, IList<DeviceStatus> newStatus);

        
    }
}
