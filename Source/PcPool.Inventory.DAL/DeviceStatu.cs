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
    
    public partial class DeviceStatu
    {
        public DeviceStatu()
        {
            this.DeviceInstances = new HashSet<DeviceInstance>();
        }
    
        public int DeviceStatusId { get; set; }
        public string DeviceStatusEnglishName { get; set; }
    
        public virtual ICollection<DeviceInstance> DeviceInstances { get; set; }
    }
}