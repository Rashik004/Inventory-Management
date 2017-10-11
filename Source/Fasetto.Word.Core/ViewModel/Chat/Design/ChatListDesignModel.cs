using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The design-time data for a <see cref="ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static ChatListDesignModel Instance => new ChatListDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Dashboard",
                    Page = ApplicationPage.Dashboard

                },
                new ChatListItemViewModel
                {
                    Name = "Loan In/Out",
                    Page = ApplicationPage.ChangeStatus
                },
                new ChatListItemViewModel
                {
                    Name = "Add new Item",
                    Page = ApplicationPage.AddItem

                },
                new ChatListItemDesignModel()
                {
                    Name = "Add Item Type",
                    Page = ApplicationPage.AddItemType
                },
                new ChatListItemDesignModel()
                {
                    Name = "Add new user",
                    Page = ApplicationPage.Register
                }
            };
        }

        #endregion
    }
}
