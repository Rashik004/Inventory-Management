//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PcPool.Inventory.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReservationList
    {
        public int ReservationId { get; set; }
        public int ReserverUserId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public int EqupmentTypeId { get; set; }
        public Nullable<System.DateTime> ReservationDate { get; set; }
        public int DeviceTypeId { get; set; }
    
        public virtual DeviceType DeviceType { get; set; }
        public virtual User User { get; set; }
    }
}