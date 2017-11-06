using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.BusinessLayer.Interfaces;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The View Model for a login screen
    /// </summary>
    public class UserListItemViewModel : BaseViewModel
    {

        private readonly IInventoryDeviceProvider _inventoryDeviceStatusProvider;

        public string UserName { get; set; }

        public string CurrentUserType { get; set; }
    }
}