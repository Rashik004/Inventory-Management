using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
    public class InventoryDeviceProvider: IInventoryDeviceStatusProvider
    {
        //public IList<DeviceInstance> GetAll()
        //{


        //}



        //private DeviceInstance ConvertToModel(DataAccessLayer.PcPoolDBaseModel.DeviceInstance arg)
        //{
        //    var deviceInstance = new DeviceInstance();

        //    deviceInstance.DeviceStatus = (DeviceStatus)arg.DeviceStatusId;
        //    deviceInstance.DeviceType = arg.DeviceType.DevicaeName;
        //    //deviceInstance.Model = arg.Model;
        //    deviceInstance.Description = arg.Description;
        //    return deviceInstance;
        //}

        public bool AddnewItem(DeviceInstance deviceInstance)
        {
            var ctx=new PcPoolEntities();
            try
            {
                var test = ctx.DeviceInstances.FirstOrDefault();
                test.Description = "Desc changed";
                ctx.DeviceInstances.Add(test);
                var state = ctx.Entry(test).State;
                ctx.SaveChanges();
                state = ctx.Entry(test).State;
            }
            catch (Exception ex)
            {

                return false;
            }
            return true;
        }

        public IList<DeviceInstance> GetAll(DeviceStatus deviceStatus=DeviceStatus.None, int deviceTypeId=0)
        {
            var ctx = new PcPoolEntities();

            var devices = ctx.DeviceInstances.Join(ctx.DeviceTypes,
                di => di.DeviceTypeId,
                dt => dt.DeviceTypeId,
                (di, dt) => new DeviceInstance()
                {
                    DeviceType = dt.DevicaeName,
                    DeviceTypeId = dt.DeviceTypeId,
                    Description = dt.DeviceDescription
                });
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

        public bool ChangeStatusBySerialNo(string serialNo, DeviceStatus newStatus)
        {
            var ctx=new PcPoolEntities();
            var device = ctx.DeviceInstances.FirstOrDefault(di => di.SeriaNo == serialNo);
            if (device == null)
            {
                return false;
            }
            device.DeviceStatusId = (int)newStatus;

            //ctx.DeviceInstances.

            try
            {
                ctx.DeviceInstances.Attach(device);
                //ctx.Entry().State = EntityState.Modified;
                var state = ctx.Entry(device).State;
                ctx.Entry(device).State = EntityState.Modified;
                var newState= ctx.Entry(device).State;
                ctx.SaveChanges();
                //newState= ctx.Entry(device).State;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
                return true;
        }

        private static bool UpdateDeviceStatus(DeviceStatus newStatus, DataAccessLayer.PcPoolDBaseModel.DeviceInstance device, PcPoolEntities ctx)
        {
            device.DeviceStatusId = (int) newStatus;
            //ctx.DeviceInstances.

            try
            {
                ctx.DeviceInstances.Attach(device);
                var entry = ctx.Entry(device);
                entry.Property(s => s.DeviceStatusId).IsModified = true;
                ctx.SaveChanges();
            }
            catch (Exception)
            {
                Debugger.Break();
                return false;
            }
            return true;
        }

        public bool ChangeStatusByRfid(string rfid, DeviceStatus newStatus)
        {
            var ctx = new PcPoolEntities();
            var device = ctx.DeviceInstances.FirstOrDefault(di => di.RFID == rfid);
            if (device == null)
            {
                return false;
            }
            return UpdateDeviceStatus(newStatus, device, ctx);
        }

        public bool ChangeStatusBySerialNo(int deviceId, DeviceStatus newStatus)
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
