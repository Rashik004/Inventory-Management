using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    public class DeviceReservation: ModelBase
    {
        public int ReservationId { get; set; }

        public int ReserverUserId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int DeviceTypeId { get; set; }

        public DateTime? ReservationDate { get; set; }

        public DeviceType DeviceType { get; set; }

        public UserInitials User { get; set; }
    }
}
