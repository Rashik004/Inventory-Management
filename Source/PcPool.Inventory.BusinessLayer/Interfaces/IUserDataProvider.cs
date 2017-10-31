using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;

namespace PcPool.Inventory.BusinessLayer.Interfaces
{
    public interface IUserDataProvider
    {
        Model.User VerifyUser(string userName, string password);

        Model.User AddNewUser(Model.User user);
    }
}
