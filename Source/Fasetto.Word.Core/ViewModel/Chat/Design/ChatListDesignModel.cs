using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PcPool.Inventory.BusinessLayer;
using PcPool.Inventory.Model;

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
            LoggedInUserData.UserChanged += OnUserChanged;
            Items = new ObservableCollection<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Dashboard",
                    Page = ApplicationPage.Dashboard

                }
            };

        }

        private void OnUserChanged(object sender, EventArgs e)
        {
            if (LoggedInUserData.UserId != 0
                && (LoggedInUserData.UserType == UserType.Admin
                    || LoggedInUserData.UserType == UserType.SuperAdmin))
            {

                Items.Add(new ChatListItemViewModel
                {
                    Name = "Loan In/Out",
                    Page = ApplicationPage.ChangeStatus
                });

                Items.Add(new ChatListItemViewModel
                {
                    Name = "Add new Item",
                    Page = ApplicationPage.AddItem
                });

                Items.Add(new ChatListItemViewModel
                {
                    Name = "Add Item Type",
                    Page = ApplicationPage.AddItemType
                });

                Items.Add(new ChatListItemViewModel
                {
                    Name = "Add new user",
                    Page = ApplicationPage.Register
                });

            }
        }

        #endregion
    }
}
