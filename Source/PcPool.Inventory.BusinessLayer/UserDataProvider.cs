using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;

namespace PcPool.Inventory.BusinessLayer
{
    public class UserDataProvider
    {
        public User VerifyUser(string userName, string password)
        {
            var ctx=new PcPoolEntities();
            var users = ctx.Users.ToList();
            return null;
        }
    }
}
