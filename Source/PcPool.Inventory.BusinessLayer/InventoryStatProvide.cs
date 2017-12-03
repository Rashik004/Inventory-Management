using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.DAL;
using PcPool.DAL.Models;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;
using DeviceType = PcPool.Inventory.Model.DeviceType;

namespace PcPool.Inventory.BusinessLayer
{
    public class InventoryStatProvide:IInventoryStatProvide
    {
        public IList<InventoryItemStat> GetInventoryStatus()
        {
            using (var ctx = new PcPoolEntities())
            {
                var devicesTypes = ctx.DeviceTypes;

                var result = new List<InventoryItemStat>();
                try
                {
                    foreach (var deviceType in devicesTypes)
                    {
                        var inStock = ctx.
                            DeviceInstances.
                            Count(di => di.DeviceTypeID == deviceType.DeviceTypeID
                                        && di.DeviceStatusID.Value == (int)DeviceStatus.InStock);
                        var loaned = ctx.
                            DeviceInstances.
                            Count(di => di.DeviceTypeID == deviceType.DeviceTypeID
                                        && di.DeviceStatusID.Value == (int)DeviceStatus.Loaned);

                        var maintance = ctx.
                            DeviceInstances.
                            Count(di => di.DeviceTypeID == deviceType.DeviceTypeID
                                        && di.DeviceStatusID.Value == (int)DeviceStatus.Maintanace);

                        var total = ctx.DeviceInstances.
                            Count(di => di.DeviceTypeID == deviceType.DeviceTypeID);
                        result.Add(new InventoryItemStat()
                        {
                            Loaned = loaned,
                            InStock = inStock,
                            Maintanace = maintance,
                            Total = total,
                            ItemName = deviceType.DevicaeName,
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return result; 
            }
        }

        public List<DeviceType> GetDeviceTypes()
        {
            var ctx=new PcPoolEntities();
            var dbDeviceTypes = ctx.DeviceTypes.Select(dt=>new DeviceType()
            {
                DeviceName = dt.DevicaeName,
                DeviceTypeId = dt.DeviceTypeID
            }).ToList();
            return dbDeviceTypes;
        }

        private DeviceType ConvertDeviceType(PcPoolModels.DeviceType arg)
        {
            return new DeviceType()
            {
                DeviceTypeId = arg.DeviceTypeID,
                DeviceName = arg.DevicaeName
            };
        }

        public ReservationResult ReserveDevices(int deviceTypeId, int amount, bool checkOnly=false)
        {
            using (var ctx = new PcPoolEntities())
            {
                var inStock = ctx.
                    DeviceInstances.
                    Count(di => di.DeviceTypeID == deviceTypeId
                                && di.DeviceStatusID.Value == (int) DeviceStatus.InStock);

                //var reserved =
                //    ctx.ReservationLists.Count(rl => rl.DeviceTypeID == deviceTypeId && rl.EndDate >= DateTime.UtcNow);
                //var reserved = 0;
                var reservationList = ctx.ReservationLists.Where(s => s.DeviceTypeID == deviceTypeId);
                var reserved = reservationList.Any() ? reservationList.Sum(rl => rl.Amount) : 0;

                var availableDevices = inStock - reserved;
                var result = new ReservationResult()
                {
                    IsPossible = availableDevices >= amount,
                    NumberOfAvailableDevice = availableDevices > 0 ? availableDevices : 0
                };

                if (!result.IsPossible || checkOnly)
                    return result;
                ctx.ReservationLists.Add(new PcPoolModels.ReservationList

                {
                    UserID = LoggedInUserData.UserId,
                    DeviceTypeID = deviceTypeId,
                    Amount = amount,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(-7)
                    
                });

                ctx.SaveChanges();
                return result;

            }
        }
    }
}
