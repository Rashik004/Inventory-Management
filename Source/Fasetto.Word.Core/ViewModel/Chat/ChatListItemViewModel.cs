using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model for each chat list item in the overview chat list
    /// </summary>
    public class ChatListItemViewModel : BaseViewModel
    {

        public ICommand GotoPageCommand { get; set; }
        /// <summary>
        /// The display name of this chat list
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The latest message from this chat
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The initials to show for the profile picture background
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// The RGB values (in hex) for the background color of the profile picture
        /// For example FF00FF for Red and Blue mixed
        /// </summary>
        public string ProfilePictureRGB { get; set; } 

        /// <summary>
        /// True if there are unread messages in this chat 
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// True if this item is currently selected
        /// </summary>
        public bool IsSelected { get; set; }

        public ApplicationPage Page { get; set; }

        public ChatListItemViewModel()
        {
            GotoPageCommand=new RelayCommand(GotoPage);
        }

        private void GotoPage()
        {
            //if (pag)
            //{
            //    IoC.Application.GoToPage(ApplicationPage.Dashboard);
            //}

            //else if(Name=="Loan In")
            IoC.Application.GoToPage(Page);
        }
    }
}
