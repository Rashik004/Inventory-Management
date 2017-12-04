using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcPool.Inventory.Model;

namespace Fasetto.Word.Core.ViewModelConverter
{
    public static class ModelToViewModelConverter
    {
        public static InventoryItemViewModel InventoryItemStatConverter(InventoryItemStat arg)
        {
            return new InventoryItemViewModel()
            {
                ItemName = arg.ItemName,
                InStockCount = arg.InStock,
                MaintanaceCount = arg.Maintanace,
                LoanedCount = arg.Loaned,
                TotalCount = arg.Total,
                ReservedCount = arg.ReservedCount
            };
        }

        public static UserListItemViewModel UserInfoConverter(User arg)
        {
            return new UserListItemViewModel()
            {
                UserName = arg.UserName,
                CurrentUserType = arg.UserType.ToString()
            };
        }
    }
}
