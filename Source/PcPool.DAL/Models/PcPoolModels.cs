using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.DAL.Models
{
    public class PcPoolModels
    {
        public class DeviceInstance
        {

            public int DeviceInstanceID { get; set; }

            public Nullable<int> ManufacturingYear { get; set; }

            public string SeriaNo { get; set; }

            public string RFID { get; set; }

            public string DescriptionTitle { get; set; }

            public string Description { get; set; }

            public Nullable<int> DeviceStatusID { get; set; }

            public int DeviceTypeID { get; set; }

        }

        public class DeviceStatus
        {

            public int DeviceStatusID { get; set; }

            public string DeviceStatusEnglishName { get; set; }

        }

        public class DeviceStatusHistory
        {

            public int DeviceStatusHistoryID { get; set; }

            public int DeviceInstanceID { get; set; }

            public Nullable<System.DateTime> ModificationDate { get; set; }

            public int ModifiedByUserID { get; set; }

            public int NewStatusID { get; set; }

        }

        public class DeviceType
        {

            public int DeviceTypeID { get; set; }

            public string DevicaeName { get; set; }

            public string DeviceDescription { get; set; }

            public string DeviceModel { get; set; }

            public string DeviceVersion { get; set; }

            public string DeviceVendor { get; set; }

        }

        public class ReservationList
        {

            public int ReservationListID { get; set; }

            public int UserID { get; set; }

            public Nullable<System.DateTime> StartDate { get; set; }

            public Nullable<System.DateTime> EndDate { get; set; }

            public int DeviceTypeID { get; set; }

            public int Amount { get; set; }

            public virtual DeviceType DeviceType { get; set; }

            public virtual User User { get; set; }

        }

        public class User
        {

            public User()
            {

                this.ReservationLists = new HashSet<ReservationList>();

            }


            public int UserID { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string UserName { get; set; }

            public string Email { get; set; }

            public string Designation { get; set; }

            public string Address { get; set; }

            public string Title { get; set; }

            public int UserTypeID { get; set; }

            public virtual ICollection<ReservationList> ReservationLists { get; set; }

        }

        public class UserType
        {

            public int UserTypeID { get; set; }

            public string UserTypeEnglishName { get; set; }

        }
    }
}
