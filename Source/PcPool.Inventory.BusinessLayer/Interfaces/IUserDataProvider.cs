﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.DataAccessLayer.PcPoolDBaseModel;

namespace PcPool.Inventory.BusinessLayer.Interfaces
{
    public interface IUserDataProvider
    {
        User VerifyUser(string userName, string password);

        bool AddNewUser(Model.User user);
    }
}
