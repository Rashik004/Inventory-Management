using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for the overview chat list
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        /// <summary>
        /// The chat list items for the list
        /// </summary>
        public ObservableCollection<ChatListItemViewModel> Items { get; set; }
    }
}
