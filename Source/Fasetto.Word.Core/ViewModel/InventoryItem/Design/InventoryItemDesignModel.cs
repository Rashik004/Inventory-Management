namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListItemViewModel"/>
    /// </summary>
    public class InventoryItemDesignModel : InventoryItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static InventoryItemDesignModel Instance => new InventoryItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public InventoryItemDesignModel()
        {
            ItemName = "Projector";
            InStockCount = 20;
            LoanedCount = 12;
            MaintanaceCount = 2;
        }

        #endregion
    }
}
