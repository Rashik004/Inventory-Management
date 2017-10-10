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
                    Initials = "LM",
                    Message = "This chat app is awesome! I bet it will be fast too",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable = true,
                    Page = ApplicationPage.Dashboard
                    //IsSelected = true

                },
                new ChatListItemViewModel
                {
                    Name = "Loan In/Out",
                    Initials = "JA",
                    Message = "Hey dude, here are the new icons",
                    ProfilePictureRGB = "fe4503",
                    Page = ApplicationPage.ChangeStatus
                },
                new ChatListItemViewModel
                {
                    Name = "Add new Item",
                    Initials = "PL",
                    Message = "The new server is up, got 192.168.1.1",
                    ProfilePictureRGB = "00d405",
                    Page = ApplicationPage.AddItem

                },
                new ChatListItemDesignModel()
                {
                    Name = "Add Item Type",
                    Page = ApplicationPage.AddItemType
                }
            };
        }

        #endregion
    }
}
