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

        public bool AddnewItemType(DeviceType newType)
        {
            var ctx=new PcPoolEntities();
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
            return device != null && UpdateDeviceStatusAndHistory(newStatus, userId, device, ctx);
        }




        public bool ChangeStatusByRfid(string rfid, DeviceStatus newStatus, int userId)
        {
            var ctx = new PcPoolEntities();
            var device = ctx.DeviceInstances.FirstOrDefault(di => di.RFID == rfid);
            return device != null && UpdateDeviceStatusAndHistory(newStatus, userId, device, ctx);
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

        private void AddDeviceStatusHistory(PcPoolEntities ctx, int deviceInstanceId, DeviceStatus newDeviceStatus, int userId)
        {
            //var ctx=new PcPoolEntities();
            ctx.DeviceStatusHistories.Add(new PcPoolModels.DeviceStatusHistory()
            {
                DeviceInstanceID = deviceInstanceId,
                ModificationDate = DateTime.Now,
                ModifiedByUserID = userId,
                NewStatusID = (int)newDeviceStatus
            });
        }

        private bool UpdateDeviceStatusAndHistory(DeviceStatus newStatus, int userId, PcPoolModels.DeviceInstance device, PcPoolEntities ctx)
        {
            var status = UpdateDeviceStatus(newStatus, device, ctx);
            if (status)
            {
                AddDeviceStatusHistory(ctx, device.DeviceInstanceID, newStatus, userId);
            }
            return status;
        }

        private static bool UpdateDeviceStatus(DeviceStatus newStatus, PcPoolModels.DeviceInstance device, PcPoolEntities ctx)
        {
            if (newStatus == DeviceStatus.Loaned)
            {
                var inventoryStatProvider = new InventoryStatProvide();
                var result = inventoryStatProvider.ReserveDevices(device.DeviceTypeID, 1, true);
                if (!result.IsPossible)
                {
                    return false;
                }
            }
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
    }
}
