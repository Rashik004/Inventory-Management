using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;
using PcPool.Inventory.BusinessLayer.Interfaces;

namespace PcPool.Inventory.BusinessLayer
{
    public class UserDataProvider: IUserDataProvider
    {
        public User VerifyUser(string userName, string password)
        {
            var ctx=new PcPoolEntities();
            var user = ctx.Users.FirstOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }
    }
}
