using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceType = PcPool.Inventory.Model.DeviceType;

namespace PcPool.Inventory.BusinessLayer
{
    public class InventoryStatProvide:IInventoryStatProvide
    {
        public IList<InventoryItemStat> GetInventoryStatus()
        {
            var ctx=new PcPoolEntities();
            var devicesTypes = ctx.DeviceTypes;
            var result=new List<InventoryItemStat>();
            foreach (var deviceType in devicesTypes)
            {
                var inStock = ctx.
                    DeviceInstances.
                    Count(di => di.DeviceTypeId == deviceType.DeviceTypeId
                                && di.DeviceStatusId.Value == (int) DeviceStatus.InStock);
                var loaned = ctx.
                    DeviceInstances.
                    Count(di => di.DeviceTypeId == deviceType.DeviceTypeId
                                && di.DeviceStatusId.Value == (int) DeviceStatus.Loaned);

                var maintance = ctx.
                    DeviceInstances.
                    Count(di => di.DeviceTypeId == deviceType.DeviceTypeId
                                && di.DeviceStatusId.Value == (int)DeviceStatus.Maintanace);

                var total = ctx.DeviceInstances.
                    Count(di => di.DeviceTypeId == deviceType.DeviceTypeId);
                result.Add(new InventoryItemStat()
                {
                    Loaned = loaned,
                    InStock = inStock,
                    Maintanace = maintance,
                    Total = total,
                    ItemName = deviceType.DevicaeName,
                });
            }
            return result;
            //var inventoryItemStat = (from device in devices
            //                         let typeDevices = ctx.DeviceInstances.Where(di => di.DeviceTypeId == device.DeviceTypeId)
            //                         let inStockCount = typeDevices.Count(td => td.DeviceStatusId == (int)DeviceStatus.InStock)
            //                         let maintanceCount = typeDevices.Count(td => td.DeviceStatusId == (int)DeviceStatus.Maintanace)
            //                         let loanedCount = typeDevices.Count(td => td.DeviceStatusId == (int)DeviceStatus.Loaned)
            //                         select new InventoryItemStat()
            //                         {
            //                             ItemName = device.DevicaeName,
            //                             Loaned = loanedCount,
            //                             Maintanace = maintanceCount,
            //                             InStock = inStockCount
            //                         }).ToList();
            //return inventoryItemStat;
            //return (from device in devices
            //    let typeDevices = ctx.DeviceInstances.Where(di => di.DeviceTypeId == device.DeviceTypeId)
            //    let inStockCount = typeDevices.Count(td => td.DeviceStatusId == (int) DeviceStatus.InStock)
            //    let maintanceCount = typeDevices.Count(td => td.DeviceStatusId == (int) DeviceStatus.Maintanace)
            //    let loanedCount = typeDevices.Count(td => td.DeviceStatusId == (int) DeviceStatus.Loaned)
            //    select new InventoryItemStat()
            //    {
            //        ItemName = device.DevicaeName, Loaned = loanedCount, Maintanace = maintanceCount, InStock = inStockCount
            //    }).ToList();
        }

        public List<DeviceType> GetDeviceTypes()
        {
            var ctx=new PcPoolEntities();
            var dbDeviceTypes = ctx.DeviceTypes.Select(dt=>new DeviceType()
            {
                DeviceName = dt.DevicaeName,
                DeviceTypeId = dt.DeviceTypeId
            }).ToList();
            return dbDeviceTypes;
        }

        private DeviceType ConvertDeviceType(DataAccessLayer.PcPoolDBaseModel.DeviceType arg)
        {
            return new DeviceType()
            {
                DeviceTypeId = arg.DeviceTypeId,
                DeviceName = arg.DevicaeName
            };
        }
    }
}
