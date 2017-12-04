namespace Fasetto.Word.Core
{
    public class InventoryItemViewModel : BaseViewModel
    {

        public string ItemName { get; set; }

        public int InStockCount { get; set; }

        public int LoanedCount { get; set; }

        public int MaintanaceCount { get; set; }

        public int ReservedCount { get; set; }


        public int TotalCount { get; set; }

    }
}
