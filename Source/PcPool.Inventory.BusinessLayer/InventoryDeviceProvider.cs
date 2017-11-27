using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceInstance = PcPool.Inventory.Model.DeviceInstance;
using DeviceType = PcPool.Inventory.Model.DeviceType;
using PcPool.DAL;
using PcPool.DAL.Models;

namespace PcPool.Inventory.BusinessLayer
{
    public class InventoryDeviceProvider: IInventoryDeviceProvider
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

        public bool AddnewItemType(DeviceType newType)
        {
            var ctx=new PcPoolEntities();
            //var as=new PcPoolModels.DeviceType();
            var dbModel = new PcPoolModels.DeviceType()
            {
                DevicaeName = newType.DeviceName,
                DeviceDescription = newType.Description,
                DeviceModel = newType.Model,
                DeviceVersion = newType.Version
            };
            ctx.DeviceTypes.Add(dbModel);
            ctx.SaveChanges();
            return true;
        }

        public bool AddnewItem(DeviceInstance deviceInstance)
        {
            var ctx=new PcPoolEntities();
            try
            {
                //var test = ctx.DeviceInstances.FirstOrDefault();
                //test.Description = "Desc changed";
                //ctx.DeviceInstances.Add(test);
                //var state = ctx.Entry(test).State;
                //ctx.SaveChanges();
                //state = ctx.Entry(test).State;
                ctx.DeviceInstances.Add(new PcPoolModels.DeviceInstance()
                {
                    DeviceTypeID = deviceInstance.DeviceTypeId,
                    Description = deviceInstance.Description,
                    DescriptionTitle = deviceInstance.DescriptionTitle,
                    SeriaNo = deviceInstance.SeriaNo,
                    RFID = deviceInstance.RFID,
                    DeviceStatusID = (int)deviceInstance.DeviceStatus,
                    ManufacturingYear = deviceInstance.ManufacturingYear
                    
                });
                ctx.SaveChanges();
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

            var devices = GetDeviceDetails(ctx);
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

        private static IQueryable<DeviceInstance> GetDeviceDetails(PcPoolEntities ctx)
        {
            var devices = ctx.DeviceInstances.Join(ctx.DeviceTypes,
                di => di.DeviceTypeID,
                dt => dt.DeviceTypeID,
                (di, dt) => new DeviceInstance()
                {
                    DeviceName = dt.DevicaeName,
                    DeviceTypeId = dt.DeviceTypeID,
                    Description = di.Description,
                    DescriptionTitle = di.DescriptionTitle,
                    Id = di.DeviceInstanceID,
                    ManufacturingYear = di.ManufacturingYear.Value,
                    Model = dt.DeviceModel,
                    DeviceStatus = (DeviceStatus) di.DeviceStatusID.Value,
                    SeriaNo = di.SeriaNo,
                    RFID = di.RFID
                });
            return devices;
        }

        public bool ChangeStatusBySerialNo(string serialNo, DeviceStatus newStatus, int userId)
        {
            var ctx=new PcPoolEntities();
            var device = ctx.DeviceInstances.FirstOrDefault(di => di.SeriaNo == serialNo);
            if (device == null)
            {
                return false;
            }
            AddDeviceStatusHistory(ctx, device.DeviceInstanceID, newStatus, userId);


            return UpdateDeviceStatus(newStatus, device, ctx);
        }

        private static bool UpdateDeviceStatus(DeviceStatus newStatus, PcPoolModels.DeviceInstance device, PcPoolEntities ctx)
        {
            //device.DeviceStatusID.Value = (int)newStatus;
            device.DeviceStatusID = (int)newStatus;
            try
            {
                ctx.DeviceInstances.Attach(device);
                ctx.Entry(device).State = EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        private void AddDeviceStatusHistory(PcPoolEntities ctx, int deviceInstanceId, DeviceStatus newDeviceStatus, int userId)
        {
            //var ctx=new PcPoolEntities();
            ctx.DeviceStatusHistories.Add(new PcPoolModels.DeviceStatusHistory()
            {
                DeviceInstanceID = deviceInstanceId,
                ModificationDate = DateTime.Now,
                ModifiedByUserID = userId,
                NewStatusID = (int) newDeviceStatus
            });
            //ctx.SaveChanges();
        }
        public bool ChangeStatusByRfid(string rfid, DeviceStatus newStatus, int userId)
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

        public ReservationResult ReserveDevices(int deviceTypeId, int amount)
        {
            using (var ctx=new PcPoolEntities())
            {
                var availbleDevices = ctx.DeviceTypes.Count(dt => dt.DeviceTypeID == deviceTypeId);
                return new ReservationResult()
                {
                    IsPossible = availbleDevices>=amount,
                    NumberOfAvailableDevice = availbleDevices
                };
            }
        }

        public DeviceInstance GetItemBySerialId(string serialId)
        {
            var ctx=new PcPoolEntities();
            return GetDeviceDetails(ctx).FirstOrDefault(dd=>dd.SeriaNo==serialId);
        }

        public DeviceInstance GetItemByRfid(string rfid)
        {
            var ctx = new PcPoolEntities();
            return GetDeviceDetails(ctx).FirstOrDefault(dd => dd.SeriaNo == rfid);
        }
    }
}
