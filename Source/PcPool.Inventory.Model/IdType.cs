using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcPool.Inventory.Model
{
    //public class IdType
    //{
    //    public int SerialId { get; set; }

    //    public string Rfid { get; set; }

    //    public string SerialNo { get; set; }

    //}

    public enum IdType
    {
        SerialId=0,
        Rfid,
        SerialNo
    }
}
