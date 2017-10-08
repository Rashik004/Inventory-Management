using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceInstance = PcPool.Inventory.Model.DeviceInstance;

namespace PcPool.Inventory.BusinessLayer
{
    public class InventoryDeviceProvider: IInventoryDeviceProvider
    {
        //public IList<DeviceInstance> GetAll()
        //{


        //}



        private DeviceInstance ConvertToModel(DataAccessLayer.PcPoolDBaseModel.DeviceInstance arg)
        {
            var deviceInstance = new DeviceInstance();

            deviceInstance.DeviceStatus = (DeviceStatus)arg.DeviceStatusId;
            deviceInstance.DeviceType = arg.DeviceType.DevicaeName;
            deviceInstance.Model = arg.Model;
            deviceInstance.Description = arg.Description;
            return deviceInstance;
        }

        public IList<DeviceInstance> GetAll(DeviceStatus deviceStatus=DeviceStatus.None, int deviceTypeId=0)
        {
            var ctx = new PcPoolEntities();

            var devices = ctx.DeviceInstances.Select(ConvertToModel);
            if (deviceStatus != DeviceStatus.None)
            {
                devices = devices.Where(d => d.DeviceStatus == deviceStatus);
            }
            if (deviceTypeId != 0)
            {
                devices = devices.Where(d => d.DeviceTypeId == deviceTypeId);
            }
            return devices.ToList();
        }

        public bool ChangeStatus(int deviceId, DeviceStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public bool ChangeStatus(int deviceId, IList<DeviceStatus> newStatus)
        {
            throw new NotImplementedException();
        }

        public bool ChangeDeviceStatusByDeviceType(int deviceTypeId, int deviceCount)
        {
            throw new NotImplementedException();

        }

        public bool IsTransitionPossible(int deviceId, DeviceStatus newStatus)
        {
            throw new NotImplementedException();
        }

        public bool IsTransitionPossible(int deviceId, IList<DeviceStatus> newStatus)
        {
            throw new NotImplementedException();
        }
    }
}
