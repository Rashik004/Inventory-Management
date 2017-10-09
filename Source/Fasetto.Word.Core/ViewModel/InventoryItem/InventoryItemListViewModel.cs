using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class InventoryItemListViewModel : BaseViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        //public static InventoryItemListViewModel Instance => new InventoryItemListViewModel();

        #endregion

        public List<InventoryItemViewModel> Items { get; set; }
    }
}
